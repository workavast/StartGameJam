using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts
{
    public class PlayerGameDataInstaller : MonoInstaller
    {
        [SerializeField, Min(0)] private int initialDifficulty;
        
        public override void InstallBindings()
        {
#if !UNITY_EDITOR
            initialDifficulty = 0;
#endif
            
            Container.BindInterfacesAndSelfTo<PlayerGameData>().FromNew().AsSingle().WithArguments(initialDifficulty).NonLazy();
        }
    }
}