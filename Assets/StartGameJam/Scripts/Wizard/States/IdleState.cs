using System;
using UnityEngine;

namespace StartGameJam.Scripts.Wizard.States
{
    public class IdleState : WizardStateBase
    {
        public override WizardState WizardState => WizardState.Idle;
        public override event Action<WizardState> OnStateChange;

        public IdleState(PlayerMovement playerMovement) : base(playerMovement)
        {
        }
        
        public override void Enter()
        {
            Wizard.playetAnim.Play("Idle");
            Wizard.Stop();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            
        }
    }
}