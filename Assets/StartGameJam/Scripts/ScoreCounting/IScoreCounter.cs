using System;

namespace StartGameJam.Scripts.ScoreCounting
{
    public interface IScoreCounter
    {
        public int PrevScoreRecord { get; }
        public int Score { get; }
        
        public event Action<int> OnChangeScore; 
    }
}