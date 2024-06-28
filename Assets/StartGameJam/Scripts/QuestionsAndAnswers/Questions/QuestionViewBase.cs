using System;
using UnityEngine;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    public abstract class QuestionViewBase: MonoBehaviour
    {
        public abstract event Action<bool> OnAnswering;

        public abstract void Load();
    }
}