using System;
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

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        
        _mover.OnContinue += StartRun;
        _mover.OnStop += StopRun;
        
        if(_mover.CanMove)
            StartRun();

        _playerGameData.HealthPoints.OnChange += TakeDamageAnim;
    }
    
    private void StartRun() 
        => _anim.SetBool("isRunning", true);

    private void TakeDamageAnim()
    {
        if (!(_playerGameData.HealthPoints.CurrentValue == 0))
        {
            print(_playerGameData.HealthPoints.CurrentValue);
            _anim.Play("Hit");
        }
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

    public event Action OnDied;
    
    public void InvokeDeath() 
        => StartCoroutine(Death());

    private IEnumerator Death()
    {
        _anim.Play("Death");
        var curTime = 0f;
        var deathLenght = _anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        while (deathLenght > curTime)
        {
            yield return new WaitForEndOfFrame();
            curTime += Time.deltaTime;
        }
        yield return new WaitForSeconds(0.25f);
        OnDied?.Invoke();
        Destroy(gameObject);
    }
}
