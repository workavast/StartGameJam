using Zenject;

namespace StartGameJam.Scripts
{
    public class PlayerGameDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
#if !UNITY_EDITOR
            initialDifficulty = 0;
#endif
            
            Container.BindInterfacesAndSelfTo<PlayerGameData>().FromNew().AsSingle().NonLazy();
        }
    }
}