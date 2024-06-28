using System.Collections.Generic;
using UnityEngine;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    [CreateAssetMenu(fileName = nameof(QuestionsConfigsSet), menuName = "StartGameJam/Configs/" + nameof(QuestionsConfigsSet))]
    public class QuestionsConfigsSet : ScriptableObject
    {
        [SerializeField] private List<InputFieldQuestionConfig> data;
    
        public IReadOnlyList<InputFieldQuestionConfig> Data => data;
    }
}