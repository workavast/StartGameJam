using StartGameJam.Scripts.ScenesLoading;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Screens
{
    public class GameplayScreen : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        
        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void _LoadMainMenuScene()
            => _sceneLoader.LoadScene(0);
    }
}