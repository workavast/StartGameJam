using UnityEngine;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    [CreateAssetMenu(fileName = nameof(InputFieldQuestionConfig), menuName = "StartGameJam/Configs/" + nameof(InputFieldQuestionConfig))]
    public class InputFieldQuestionConfig : ScriptableObject
    {
        [field: SerializeField, Multiline(4)] public string Description { get; private set; } 
        [field: SerializeField, Multiline(6)] public string Formula { get; private set; } 
        [field: Space]
        [field: SerializeField] public string Answer { get; private set; }
        [field: SerializeField, Min(1)] public float AnswerTime { get; private set; } = 1;
        [field: Space]
        [field: SerializeField, Min(0)] public int MinDifficulty { get; private set; }
        [field: SerializeField, Min(0)] public int MaxDifficulty { get; private set; } = 100;
        [field: SerializeField, Min(0)] public int DifficultyScale { get; private set; }
    }
}