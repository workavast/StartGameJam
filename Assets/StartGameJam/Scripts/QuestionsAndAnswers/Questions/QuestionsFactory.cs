using UnityEngine;
using Random = UnityEngine.Random;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    public class QuestionsFactory : MonoBehaviour
    {
        [SerializeField] private QuestionsConfigsSet questionsConfigsSet;

        public InputFieldQuestionConfig Create()
        {
            var randomIndex = Random.Range(0, questionsConfigsSet.Data.Count);

            return questionsConfigsSet.Data[randomIndex];
        }
    }
}