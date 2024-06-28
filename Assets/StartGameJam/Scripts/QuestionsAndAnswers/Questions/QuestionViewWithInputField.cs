using System;
using Avastrad.CustomTimer;
using StartGameJam.Scripts.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    public class QuestionViewWithInputField : QuestionViewBase
    {
        [SerializeField] private QuestionsFactory questionsFactory;
        [SerializeField] private TEXDraw texDraw;
        [SerializeField] private TMP_Text description;
        [SerializeField] private TMP_InputField inputField;

        [Inject] private GameConfig _gameConfig;

        private readonly Timer _answerTimer = new Timer(0);
        private string _answer;
        private int _triesCounter;
        
        public IReadOnlyTimer AnswerTimer => _answerTimer;
        
        public override event Action<bool> OnAnswering;

        private void Awake()
        {
            _answerTimer.OnTimerEnd += OnAnswerTimeOver;
        }

        private void Update()
        {
            _answerTimer.Tick(Time.deltaTime);
        }

        public void _ApplyAnswer()
        {
            if(inputField.text != "")
                _triesCounter++;
            var fixedAnswer = inputField.text.Replace(",", ".");
            if (fixedAnswer != _answer && _triesCounter < _gameConfig.TriesForAnswerCount)
            {
                Clear();
                return;
            }
            
            _answerTimer.SetPause();
            OnAnswering?.Invoke(fixedAnswer == _answer);
        }

        public void _Skip()
        {
            _answerTimer.SetPause();
            OnAnswering?.Invoke(false);
        }
        
        public override void Load()
        {
            var data = questionsFactory.Create();
            texDraw.text = data.Formula;
            description.text = data.Description;
            _answer = data.Answer;
            _answerTimer.SetMaxTime(data.AnswerTime);
            _triesCounter = 0;
            Clear();
        }

        private void OnAnswerTimeOver()
        {
            var fixedAnswer = inputField.text.Replace(",", ".");
            OnAnswering?.Invoke(fixedAnswer == _answer);
        }
        
        private void Clear()
        {
            inputField.text = "";
        }
    }
}