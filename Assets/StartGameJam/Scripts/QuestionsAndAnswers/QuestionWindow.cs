using System;
using UnityEngine;

namespace StartGameJam.Scripts.QuestionsAndAnswers
{
    public class QuestionWindow : MonoBehaviour
    {
        public event Action<bool> OnAnswering; 
        
        public void Show() 
            => gameObject.SetActive(true);

        public void Hide() 
            => gameObject.SetActive(false);

        public void _Correct() 
            => OnAnswering?.Invoke(true);

        public void _UnCorrect() 
            => OnAnswering?.Invoke(false);
    }
}