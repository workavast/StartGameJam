using Avastrad.EventBusFramework;

namespace StartGameJam.Scripts.EventBus
{
    public struct QuestionAnswerEvent : IEvent
    {
        public readonly bool AnswerIsCorrect;
        public readonly int QuestionDifficultyScale;

        public QuestionAnswerEvent(bool answerIsCorrect, int questionDifficultyScale)
        {
            AnswerIsCorrect = answerIsCorrect;
            QuestionDifficultyScale = questionDifficultyScale;
        }
    }
}