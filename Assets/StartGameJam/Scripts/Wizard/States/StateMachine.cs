using System.Collections.Generic;

namespace StartGameJam.Scripts.Wizard.States
{
    public class StateMachine
    {
        private readonly Dictionary<WizardState, WizardStateBase> _states = new();
        private WizardStateBase _currentState;
        
        public WizardState CurrentState => _currentState.WizardState;
        
        public StateMachine(IEnumerable<WizardStateBase> states, WizardState initialState)
        {
            foreach (var state in states)
            {
                _states.Add(state.WizardState, state);
            }

            _currentState = _states[initialState];
        }

        public void ManualUpdate() 
            => _currentState.Update();
        
        public void ManualFixedUpdate() 
            => _currentState.FixedUpdate();
        
        public void ChangeState(WizardState newState)
        {
            if(_currentState.WizardState == newState)
                return;
            
            _currentState.Exit();
            _currentState = _states[newState];
            _currentState.Enter();
        }
    }
}