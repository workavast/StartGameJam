using StartGameJam.Scripts.Moving;
using StartGameJam.Scripts.ScenesLoading;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Bootstraps
{
    public class GameplaySceneBootstrap : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private Mover _mover;
        
        [Inject]
        public void Construct(ISceneLoader sceneLoader, Mover mover)
        {
            _sceneLoader = sceneLoader;
            _mover = mover;
        }
        
        private void Start()
        {
            Time.timeScale = 1;
            _sceneLoader.Initialize(false);
            _mover.Continue();
        }
    }
}