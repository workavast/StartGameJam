using System;
using Avastrad.EventBusFramework;
using Avastrad.Storages;
using StartGameJam.Scripts.Core;
using StartGameJam.Scripts.EventBus;
using UnityEngine;

namespace StartGameJam.Scripts
{
    public class PlayerGameData : IEventReceiver<QuestionAnswerEvent>, IDisposable
    {
        private readonly GameConfig _gameConfig;
        private readonly Avastrad.EventBusFramework.EventBus _eventBus;
        private readonly IntStorage _healthPoints;
        
        public EventBusReceiverIdentifier EventBusReceiverIdentifier { get; } = new();
        public int Difficulty { get; private set; }
        public IReadOnlyStorage<int> HealthPoints => _healthPoints; 
        
        public event Action<int> OnChangeDifficulty; 
        
        public PlayerGameData(GameConfig gameConfig, Avastrad.EventBusFramework.EventBus eventBus, int initialDifficulty = 0)
        {
            _gameConfig = gameConfig;
            _eventBus = eventBus;
            Difficulty = Mathf.Clamp(initialDifficulty, 0, _gameConfig.MaxDifficulty);
            
            _eventBus.Subscribe(this);
            _healthPoints = new IntStorage(_gameConfig.HeartsCount, _gameConfig.HeartsCount);
        }

        public void TakeDamage()
            => _healthPoints.ChangeCurrentValue(-1);

        public void OnEvent(QuestionAnswerEvent t)
        {
            if (t.AnswerIsCorrect)
            {
                Difficulty = Mathf.Clamp(Difficulty + t.QuestionDifficultyScale, 0, _gameConfig.MaxDifficulty);
                OnChangeDifficulty?.Invoke(Difficulty);
            }
        }

        public void Dispose()
        {
            _eventBus?.UnSubscribe(this);
        }
    }
}