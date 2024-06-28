using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.QuestionsAndAnswers
{
    public class QuestionZone : MonoBehaviour
    {
        [SerializeField] private DamageZone damageZone;
        
        [Inject] private QuestionAnswering _questionAnswering;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IPlayer player))
            {
                _questionAnswering.OnAnswered += Result;
                _questionAnswering.InvokeQuestion();
            }
        }

        private void Result(bool answerIsCorrect)
        {
            damageZone.gameObject.SetActive(!answerIsCorrect);
        }
    }
}