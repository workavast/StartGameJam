using System;
using UnityEngine;

namespace StartGameJam.Scripts.Wizard.States
{
    public class JumpState : WizardStateBase
    {
        public override WizardState WizardState => WizardState.Jump;
        public override event Action<WizardState> OnStateChange;

        public JumpState(PlayerMovement playerMovement) : base(playerMovement)
        {
        }

        public override void Enter()
        {
            Wizard.playetAnim.Play("Jump");
        }

        public override void Exit()
        {
        }
        
        public override void Update()
        {
            if (Wizard.CheckGround())
            {
                OnStateChange?.Invoke(WizardState.Run);
            }
            else if (Wizard.Rb.velocity.y < 0)
                OnStateChange?.Invoke(WizardState.Fall);
        }

        public override void FixedUpdate()
        {
            if (Wizard.Rb.velocity.x < Wizard.MaxSpeed) 
                Wizard.Rb.AddForce(new Vector2(Wizard.acceleration, 0), ForceMode2D.Force);
        }
    }
}