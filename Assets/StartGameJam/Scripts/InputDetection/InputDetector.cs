using System;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.InputDetection
{
    public class InputDetector : ITickable
    {
        public event Action OnApplyPressed;
        
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) 
                OnApplyPressed?.Invoke();
        }
    }
}