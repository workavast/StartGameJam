using System;
using StartGameJam.Scripts.Core;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Moving
{
    public class Mover : MonoBehaviour
    {
        [Inject] private GameConfig _gameConfig;

        public bool CanMove { get; private set; }
        
        public event Action<float> OnMove;
        public event Action OnStop; 
        public event Action OnContinue; 
        
        private void Update()
        {
            if(!CanMove)
                return;
            
            var moveDistance = _gameConfig.MoveSpeed * Time.deltaTime;
            OnMove?.Invoke(moveDistance);
        }

        public void Stop()
        {
            CanMove = false;
            OnStop?.Invoke();   
        }

        public void Continue()
        {
            CanMove = true;
            OnContinue?.Invoke();
        }
    }
}