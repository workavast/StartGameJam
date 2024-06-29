using Avastrad.EventBusFramework;
using StartGameJam.Scripts.QuestionsAndAnswers.Questions;

namespace StartGameJam.Scripts.EventBus
{
    public struct QuestionAnswerEvent : IEvent
    {
        public readonly bool AnswerIsCorrect;
        public readonly int MinDifficulty;
        public readonly int MaxDifficulty;
        public readonly int QuestionDifficultyScale;

        public QuestionAnswerEvent(bool answerIsCorrect, InputFieldQuestionConfig questionConfig)
        {
            AnswerIsCorrect = answerIsCorrect;
            MinDifficulty = questionConfig.MinDifficulty;
            MaxDifficulty = questionConfig.MaxDifficulty;
            QuestionDifficultyScale = questionConfig.DifficultyScale;
        }
    }
}