using System;
using Avastrad.EventBusFramework;
using StartGameJam.Scripts.EventBus;

namespace StartGameJam.Scripts.ScoreCounting
{
    public class ScoreCounter : IScoreCounter, IEventReceiver<QuestionAnswerEvent>, IDisposable
    {
        private readonly Avastrad.EventBusFramework.EventBus _eventBus;
        public EventBusReceiverIdentifier EventBusReceiverIdentifier { get; } = new();

        public int PrevScoreRecord { get; private set; }
        public int Score { get; private set; }
        
        public event Action<int> OnChangeScore; 
        
        public ScoreCounter(Avastrad.EventBusFramework.EventBus eventBus)
        {
            _eventBus = eventBus;
            PrevScoreRecord = PlayerData.PlayerData.Instance.ScoreSettings.ScoreRecord;
            
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

        public void Dispose()
        {
            _eventBus?.UnSubscribe(this);
        }
    }
}