using StartGameJam.Scripts.Moving;
using System.Collections;
using StartGameJam.Scripts;
using UnityEngine;
using Zenject;

using StartGameJam.Scripts.Core;


[RequireComponent(typeof(Animator))]
public class WizardAnim : MonoBehaviour
{
    [Inject] private Mover _mover;
    [Inject] private PlayerGameData _playerGameData;
    [Inject] private GameOverDetection _gameOverDetection;

    private Animator _anim;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        
        _mover.OnContinue += StartRun;
        _mover.OnStop += StopRun;
        
        if(_mover.CanMove)
            StartRun();

        _playerGameData.HealthPoints.OnChange += TakeDamageAnim;
        _gameOverDetection.OnGameOver += DeathProcess;
    }
    
    private void StartRun() 
        => _anim.SetBool("isRunning", true);

    /* IEnumerator DestroyMage()
     {
         yield return new WaitForSeconds(0.5f);
         Destroy(gameObject);
     }*/
    private void DeathProcess()
    {
        //_anim.Play("Death"); // NOT WORKING
        //StartCoroutine(DestroyMage());
        Destroy(gameObject);
    }
    private void TakeDamageAnim()
    {
        _anim.Play("Hit");
    }
    
    private void StartRun(int action)
    {
        switch (action) {
            case 0:
                StartRun();
                return;
            case 1:
                _anim.Play("Attack");
                StartCoroutine(DestroyDangerous(0.6f));
                break;
        }
        StartCoroutine(RunWithDelay(0.8f));
    }

    private void StopRun() 
        => _anim.SetBool("isRunning", false);

    private IEnumerator RunWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartRun();
    }
    
    private IEnumerator DestroyDangerous(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        var dangerObjects = FindObjectsByType<DamageZone>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        if (dangerObjects.Length == 0)
            yield break;
        
        DamageZone nearestDanger = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;
        foreach (var dangerObject in dangerObjects)
        {
            float distance = Vector3.Distance(currentPosition, dangerObject.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestDanger = dangerObject;
            }
        }

        if (nearestDanger != null)
            nearestDanger.DeActivate();
    }
}
