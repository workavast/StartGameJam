using System;
using StartGameJam.Scripts.Moving;
using UnityEngine;

namespace StartGameJam.Scripts.Core
{
    public class GameOverDetection
    {
        private readonly IPlayer _player;
        private readonly Mover _mover;

        public event Action OnGameOver;
        
        public GameOverDetection(IPlayer player, Mover mover)
        {
            _player = player;
            _mover = mover;
            
            _player.OnDeathEnd += InvokeGameOver;
        }

        public void InvokeGameOver()
        {
            _mover.Stop();
            _player.OnDeathEnd -= InvokeGameOver;
            Time.timeScale = 0;
            OnGameOver?.Invoke();            
        }
    }
}