using System;
using System.Collections.Generic;
using StartGameJam.Scripts;
using StartGameJam.Scripts.Core;
using StartGameJam.Scripts.Moving;
using StartGameJam.Scripts.Wizard;
using StartGameJam.Scripts.Wizard.States;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour, IPlayer
{
    [SerializeField] private bool useDeath = true;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundCheckLayers;
    [SerializeField] private Vector2 groundCheckPointSize;
    
    [Inject] public Mover mover;
    [Inject] private PlayerGameData _playerGameData;
    [Inject] private GameConfig _gameConfig;

    public Animator playetAnim;
    public float acceleration = 5f;  // Ускорение по X
    public float jumpCooldown = 0.8f; // Время ожидания между прыжками
    public float lastJumpTime;      // Время последнего прыжка
    
    public Rigidbody2D Rb { get; private set;}
    public float MaxSpeed => _gameConfig.MoveSpeed;// Максимальная скорость по X
    
    private StateMachine _stateMachine;

    public bool isDead;
    public Action OnDied;
    public event Action OnDeathEnd;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        lastJumpTime = Time.time - jumpCooldown;
        OnDied += () => OnDeathEnd?.Invoke();
        
        List<WizardStateBase> states =new() 
        {
            new IdleState(this),
            new RunState(this),
            new JumpState(this),
            new FallState(this),
            new AttackState(this),
            new TakeDamageState(this),
            new DeathState(this),
        };

        foreach (var state in states) 
            state.OnStateChange += ChangeState;

        _stateMachine = new StateMachine(states, WizardState.Idle);
    }

    void Start()
    {
        mover.OnContinue += StartMove;
        mover.OnStop += StopMove;

        _playerGameData.HealthPoints.OnChange += TakeDamage;

        if (mover.CanMove)
            ChangeState(WizardState.Run);
        else
            ChangeState(WizardState.Idle);
    }
    
    private void Update() 
        => _stateMachine.ManualUpdate();

    private void FixedUpdate() 
        => _stateMachine.ManualFixedUpdate();
    
    public bool CheckGround()
    {
        var result = Physics2D.BoxCast(groundCheckPoint.position, groundCheckPointSize, 0,
            Vector2.down, 0, groundCheckLayers);

        return result;
    }

    public void Stop() 
        => Rb.velocity = Vector3.zero;
    
    private void StartMove(int action)
    {
        if(isDead)
            return;
        
        switch (action) {
            case 0:
                ChangeState(WizardState.Run);
                break;
            case 1:
                ChangeState(WizardState.Attack);
                break;
            default:
                Debug.Log("Out of range");
                return;
        }
    }

    private void StopMove()
    {
        if(isDead)
            return;
        ChangeState(WizardState.Idle);
    }

    private void TakeDamage()
    {
        if(useDeath && _playerGameData.HealthPoints.IsEmpty)
            ChangeState(WizardState.Death);
        else
            ChangeState(WizardState.TakeDamage);
    }

    private void ChangeState(WizardState wizardState) 
        => _stateMachine.ChangeState(wizardState);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckPointSize);
    }
}