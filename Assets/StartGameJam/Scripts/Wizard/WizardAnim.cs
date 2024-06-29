using StartGameJam.Scripts.Moving;
using System.Collections;
using StartGameJam.Scripts;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class WizardAnim : MonoBehaviour
{
    [Inject] private Mover _mover;
    
    private Animator _anim;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        
        _mover.OnContinue += StartRun;
        _mover.OnStop += StopRun;
        
        if(_mover.CanMove)
            StartRun();
    }
    
    private void StartRun() 
        => _anim.SetBool("isRunning", true);
    
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
