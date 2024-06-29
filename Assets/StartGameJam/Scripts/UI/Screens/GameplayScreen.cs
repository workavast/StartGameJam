using StartGameJam.Scripts.Core;
using StartGameJam.Scripts.QuestionsAndAnswers;
using StartGameJam.Scripts.ScenesLoading;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Screens
{
    public class GameplayScreen : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverWindow;
        [SerializeField] private QuestionWindow questionWindow;

        private ISceneLoader _sceneLoader;
        private GameOverDetection _gameOverDetection;

        [Inject]
        public void Construct(ISceneLoader sceneLoader, GameOverDetection gameOverDetection)
        {
            _sceneLoader = sceneLoader;
            _gameOverDetection = gameOverDetection;
            
            _gameOverDetection.OnGameOver += OnGameOver;
        }

        private void Awake()
        {
            gameOverWindow.SetActive(false);
        }

        public void _Restart()
            => _sceneLoader.LoadScene(2);
        
        public void _LoadMainMenuScene()
            => _sceneLoader.LoadScene(0);
        
        private void OnGameOver()
        {
            questionWindow.Hide();
            gameOverWindow.SetActive(true);
        }
    }
}