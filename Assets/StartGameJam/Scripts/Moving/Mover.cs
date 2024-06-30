using System;
using StartGameJam.Scripts.Core;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Moving
{
    public class Mover : MonoBehaviour
    {
        public bool CanMove { get; private set; }
        
        public event Action OnStop;
        public event Action<int> OnContinue;
        
        public void Stop()
        {
            CanMove = false;
            OnStop?.Invoke();   
        }

        public void Continue(int action=0)
        {
            CanMove = true;
            OnContinue?.Invoke(action);
        }
    }
}