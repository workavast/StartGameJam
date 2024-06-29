using System;
using StartGameJam.Scripts.Moving;
using UnityEngine;

namespace StartGameJam.Scripts.Core
{
    public class GameOverDetection
    {
        private readonly bool _useGameOver;
        private readonly PlayerGameData _playerGameData;
        private readonly IPlayer _player;
        private readonly Mover _mover;

        public event Action OnGameOver;
        
        public GameOverDetection(bool useGameOver, PlayerGameData playerGameData, IPlayer player, Mover mover)
        {
            _useGameOver = useGameOver;
            _playerGameData = playerGameData;
            _player = player;
            _mover = mover;
            _playerGameData.HealthPoints.OnChange += CheckDeath;
        }

        private void CheckDeath()
        {
            if (!_useGameOver)
                return;
            
            if (_playerGameData.HealthPoints.IsEmpty)
            {
                _mover.Stop();
                _player.OnDeathEnd += InvokeGameOver;
                _player.InvokeDeath();
            }
        }

        public void InvokeGameOver()
        {
            _player.OnDeathEnd -= InvokeGameOver;
            Time.timeScale = 0;
            OnGameOver?.Invoke();            
        }

    }
}