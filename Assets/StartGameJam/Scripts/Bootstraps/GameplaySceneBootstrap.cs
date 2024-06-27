using StartGameJam.Scripts.ScenesLoading;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Bootstraps
{
    public class GameplaySceneBootstrap : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void Start()
        {
            _sceneLoader.Initialize(false);
        }
    }
}