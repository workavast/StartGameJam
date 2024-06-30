using System;
using UnityEngine;

namespace StartGameJam.Scripts.Wizard.States
{
    public class RunState : WizardStateBase
    {
        public override WizardState WizardState => WizardState.Run;
        public override event Action<WizardState> OnStateChange;

        public RunState(PlayerMovement wizard) : base(wizard)
        {
        }

        public override void Enter()
        {
            Wizard.playetAnim.Play("Run");
            CheckState();
        }
        
        public override void Exit()
        {
        }
        
        public override void Update()
        {
            CheckState();
            CheckJump();
        }

        public override void FixedUpdate()
        {
            if (Wizard.Rb.velocity.x < Wizard.MaxSpeed) 
                Wizard.Rb.AddForce(new Vector2(Wizard.acceleration, 0), ForceMode2D.Force);
        }

        private void CheckJump()
        {
            if (Wizard.CheckGround())
            {
                Vector2 rayStart = new Vector2(Wizard.transform.position.x, Wizard.transform.position.y - 0.1f);
                RaycastHit2D[] hits = Physics2D.RaycastAll(rayStart, Vector2.right, 2f);
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider != null && hit.collider.gameObject.CompareTag("Obstacle") && Time.time - Wizard.lastJumpTime >= Wizard.jumpCooldown)
                    {
                        Wizard.Rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
                        Wizard.lastJumpTime = Time.time;
                        break;
                    }
                }
            }
        }
        
        private void CheckState()
        {
            if (!Wizard.CheckGround())
            {
                if (Wizard.Rb.velocity.y >= 0)
                    OnStateChange?.Invoke(WizardState.Jump);
                else
                    OnStateChange?.Invoke(WizardState.Fall);
            } 
        }
    }
}