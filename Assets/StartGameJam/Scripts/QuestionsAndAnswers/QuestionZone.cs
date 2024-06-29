using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.QuestionsAndAnswers
{
    public class QuestionZone : MonoBehaviour
    {
        [Inject] private QuestionAnswering _questionAnswering;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IPlayer player))
            {
                _questionAnswering.InvokeQuestion();
            }
        }
    }
}