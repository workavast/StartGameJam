using StartGameJam.Scripts.ScenesLoading;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Bootstraps
{
    public class MainMenuSceneBootstrap : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void Start()
        {
            Time.timeScale = 1;
            _sceneLoader.Initialize(true);
        }
    }
}