using System;
using StartGameJam.Scripts.Moving;

namespace StartGameJam.Scripts.QuestionsAndAnswers
{
    public class QuestionAnswering
    {
        private readonly QuestionWindow _questionWindow;
        private readonly Mover _mover;
        
        public event Action<bool> OnAnswered;

        public QuestionAnswering(QuestionWindow questionWindow, Mover mover)
        {
            _questionWindow = questionWindow;
            _mover = mover;
            
            _questionWindow.Hide();
            _questionWindow.OnAnswering += GetQuestionResult;
        }
        
        public void InvokeQuestion()
        {
            _mover.Stop();
            _questionWindow.Show();
        }

        public void GetQuestionResult(bool answerIsCorrect)
        {
            _questionWindow.Hide();
            OnAnswered?.Invoke(answerIsCorrect);
            _mover.Continue(answerIsCorrect ? 1:0);
        }
    }
}