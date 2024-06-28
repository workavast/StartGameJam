using StartGameJam.Scripts.Moving;
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

    private void StopRun() 
        => _anim.SetBool("isRunning", false);
}
