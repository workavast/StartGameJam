using System;

namespace StartGameJam.Scripts.Wizard.States
{
    public abstract class WizardStateBase
    {
        public abstract WizardState WizardState { get; }
        
        protected readonly PlayerMovement Wizard;

        public abstract event Action<WizardState> OnStateChange;
        
        protected WizardStateBase(PlayerMovement wizard)
        {
            Wizard = wizard;
        }
        
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}