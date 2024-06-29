using System;
using Avastrad.CustomTimer;
using StartGameJam.Scripts.Core;
using StartGameJam.Scripts.EventBus;
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

        [Inject] private PlayerGameData _playerGameData;
        [Inject] private GameConfig _gameConfig;
        [Inject] private Avastrad.EventBusFramework.EventBus _eventBus;
        
        private InputFieldQuestionConfig _currentQuestion;
        private readonly Timer _answerTimer = new Timer(0);
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
            if (fixedAnswer != _currentQuestion.Answer && _triesCounter < _gameConfig.TriesForAnswerCount)
            {
                Clear();
                return;
            }
            
            _answerTimer.SetPause();
            _eventBus.Invoke(new QuestionAnswerEvent(fixedAnswer == _currentQuestion.Answer, _currentQuestion.DifficultyScale));
            OnAnswering?.Invoke(fixedAnswer == _currentQuestion.Answer);
        }

        public void _Skip()
        {
            _answerTimer.SetPause();
            _eventBus.Invoke(new QuestionAnswerEvent(false, _currentQuestion.DifficultyScale));
            OnAnswering?.Invoke(false);
        }
        
        public override void Load()
        {
            _currentQuestion = questionsFactory.Create(_playerGameData.Difficulty);
            texDraw.text = _currentQuestion.Formula;
            description.text = _currentQuestion.Description;
            _answerTimer.SetMaxTime(_currentQuestion.AnswerTime);
            _triesCounter = 0;
            Clear();
        }

        private void OnAnswerTimeOver()
        {
            var fixedAnswer = inputField.text.Replace(",", ".");
            _eventBus.Invoke(new QuestionAnswerEvent(fixedAnswer == _currentQuestion.Answer, _currentQuestion.DifficultyScale));
            OnAnswering?.Invoke(fixedAnswer == _currentQuestion.Answer);
        }
        
        private void Clear()
        {
            inputField.text = "";
        }
    }
}