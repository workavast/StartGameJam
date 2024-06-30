using Zenject;

namespace StartGameJam.Scripts
{
    public class PlayerGameDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerGameData>().FromNew().AsSingle().NonLazy();
        }
    }
}