using System;
using Avastrad.EventBusFramework;
using StartGameJam.Scripts.Core;
using StartGameJam.Scripts.EventBus;

namespace StartGameJam.Scripts.ScoreCounting
{
    public class ScoreCounter : IScoreCounter, IEventReceiver<QuestionAnswerEvent>, IDisposable
    {
        private readonly Avastrad.EventBusFramework.EventBus _eventBus;
        private readonly GameConfig _gameConfig;
        private readonly PlayerMovement _playerMovement;
        public EventBusReceiverIdentifier EventBusReceiverIdentifier { get; } = new();

        public int PrevScoreRecord { get; private set; }
        public int Score { get; private set; }
        
        public event Action<int> OnChangeScore;

        private float _movedDistance;
        
        public ScoreCounter(Avastrad.EventBusFramework.EventBus eventBus, GameConfig gameConfig, PlayerMovement playerMovement)
        {
            _eventBus = eventBus;
            _gameConfig = gameConfig;
            _playerMovement = playerMovement;
            PrevScoreRecord = PlayerData.PlayerData.Instance.ScoreSettings.ScoreRecord;

            _playerMovement.OnMove += OnMove;
            
            _eventBus.Subscribe(this);
        }
        
        public void OnEvent(QuestionAnswerEvent t)
        {
            if (t.AnswerIsCorrect)
            {
                Score += (t.MinDifficulty + t.MaxDifficulty) / 2 * 50;
                
                if(Score > PlayerData.PlayerData.Instance.ScoreSettings.ScoreRecord)
                    PlayerData.PlayerData.Instance.ScoreSettings.SetScoreRecord(Score);
                    
                OnChangeScore?.Invoke(Score);
            }
        }

        private void OnMove(float moveDistance)
        {
            _movedDistance += moveDistance;

            if (_movedDistance >= _gameConfig.MoveScoreStep)
            {
                _movedDistance -= _gameConfig.MoveScoreStep;
                Score += _gameConfig.MoveScorePerStep;
                OnChangeScore?.Invoke(Score);
            }
        }
        
        public void Dispose()
        {
            _eventBus?.UnSubscribe(this);
            
            if(_playerMovement != null)
                _playerMovement.OnMove -= OnMove;
        }
    }
}