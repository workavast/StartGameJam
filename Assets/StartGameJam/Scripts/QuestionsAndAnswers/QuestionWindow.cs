using System;
using StartGameJam.Scripts.QuestionsAndAnswers.Questions;
using UnityEngine;

namespace StartGameJam.Scripts.QuestionsAndAnswers
{
    public class QuestionWindow : MonoBehaviour
    {
        [SerializeField] private QuestionViewBase questionView;
        
        public event Action<bool> OnAnswering;

        private void Awake()
        {
            questionView.OnAnswering += Result;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            questionView.Load();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Result(bool result)
            => OnAnswering?.Invoke(result);

        private void OnDestroy()
        {
            questionView.OnAnswering -= Result;
        }
    }
}