using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace StartGameJam.Scripts.ScenesLoading
{
    public class SceneLoader : ISceneLoader
    {
        public int LoadingSceneIndex => LOADING_SCENE_INDEX;
        
        private const int LOADING_SCENE_INDEX = 1;
        private static int _targetSceneIndex = -1;
        private readonly ILoadingScreen _loadingScreen;
        
        public event Action LoadingStarted;

        [Inject]
        public SceneLoader(ILoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen;
        }
        
        public void Initialize(bool endInstantly)
        {
            var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            if (_targetSceneIndex <= -1 || activeSceneIndex == _targetSceneIndex)
                EndLoading(endInstantly);

            if (activeSceneIndex == LoadingSceneIndex)
                StartLoadTargetScene();
        }
        
        public void LoadScene(int index)
        {
            _targetSceneIndex = index;
            
            LoadingStarted?.Invoke();
            
            _loadingScreen.StartLoading();
            SceneManager.LoadSceneAsync(LoadingSceneIndex);
        }

        private void EndLoading(bool endInstantly)
        {
            if(endInstantly)
                _loadingScreen.EndLoadingInstantly();
            else
                _loadingScreen.EndLoading();
        }
        
        private static void StartLoadTargetScene() 
            => SceneManager.LoadSceneAsync(_targetSceneIndex);
    }
}