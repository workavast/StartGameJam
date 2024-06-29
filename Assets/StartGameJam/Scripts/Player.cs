using System;
using UnityEngine;

namespace StartGameJam.Scripts
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private WizardAnim wizardAnim;
        
        public event Action OnDeathEnd;

        private void Awake()
        {
            wizardAnim.OnDied += () => OnDeathEnd?.Invoke();
        }

        public void InvokeDeath()
        {
            wizardAnim.InvokeDeath();
        }
    }
}