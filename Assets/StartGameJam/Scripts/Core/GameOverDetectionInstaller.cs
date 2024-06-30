using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Core
{
    public class GameOverDetectionInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement player;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameOverDetection>().FromNew().AsSingle().WithArguments(player).NonLazy();
        }
    }
}