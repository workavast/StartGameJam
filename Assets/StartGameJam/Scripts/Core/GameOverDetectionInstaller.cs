using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Core
{
    public class GameOverDetectionInstaller : MonoInstaller
    {
        [SerializeField] private bool useGameOver = true;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameOverDetection>().FromNew().AsSingle().WithArguments(useGameOver).NonLazy();
        }
    }
}