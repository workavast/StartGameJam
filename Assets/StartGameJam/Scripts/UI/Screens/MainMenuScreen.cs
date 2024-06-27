using StartGameJam.Scripts.ScenesLoading;
using StartGameJam.Scripts.UI.Elements;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Screens
{
    public class MainMenuScreen : MonoBehaviour
    {
        [SerializeField] private SettingsWindow settingsWindow;

        private ISceneLoader _sceneLoader;
        
        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void Start()
            => _CloseSettings();

        public void _LoadGameplayScene()
            => _sceneLoader.LoadScene(2);
        
        public void _OpenSettings()
            => settingsWindow.Show();
        
        public void _CloseSettings()
            => settingsWindow.Hide();
    }
}