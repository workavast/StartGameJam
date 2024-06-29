using System;
using UnityEngine;

namespace StartGameJam.Scripts.Core
{
    public class GameOverDetection
    {
        private readonly bool _useGameOver;
        private readonly PlayerGameData _playerGameData;

        public event Action OnGameOver;
        
        public GameOverDetection(bool useGameOver, PlayerGameData playerGameData)
        {
            _useGameOver = useGameOver;
            _playerGameData = playerGameData;
            _playerGameData.HealthPoints.OnChange += CheckDeath;
        }

        private void CheckDeath()
        {
            if (!_useGameOver)
                return;
            
            if (_playerGameData.HealthPoints.CurrentValue <= 0)
            {
                Debug.Log("Death");
                Time.timeScale = 0;
                OnGameOver?.Invoke();
            }
        }
    }
}