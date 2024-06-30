using System;
using UnityEngine;

namespace StartGameJam.Scripts.Wizard.States
{
    public class FallState : WizardStateBase
    {
        public override WizardState WizardState => WizardState.Fall;
        public override event Action<WizardState> OnStateChange;

        public FallState(PlayerMovement playerMovement) : base(playerMovement)
        {
        }

        public override void Enter()
        {
            Wizard.playetAnim.Play("Fall");
        }

        public override void Exit()
        {
        }
        
        public override void Update()
        {
            if (Wizard.CheckGround())
                OnStateChange?.Invoke(WizardState.Run);
            else if (Wizard.Rb.velocity.y >= 0)
                OnStateChange?.Invoke(WizardState.Jump);
        }

        public override void FixedUpdate()
        {
            if (Wizard.Rb.velocity.x < Wizard.MaxSpeed) 
                Wizard.Rb.AddForce(new Vector2(Wizard.acceleration, 0), ForceMode2D.Force);
        }
    }
}