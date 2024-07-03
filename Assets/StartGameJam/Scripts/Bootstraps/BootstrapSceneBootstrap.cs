using StartGameJam.Scripts.Localization;
using StartGameJam.Scripts.ScenesLoading;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Bootstraps
{
    public class BootstrapSceneBootstrap : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        
        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private async void Start()
        {
            Time.timeScale = 1;

            var locInit = new LocalizationInitializer();
            await locInit.InitLocalizationSettings();
            
            _sceneLoader.Initialize(false);
            _sceneLoader.LoadScene(0);
        }
    }
}