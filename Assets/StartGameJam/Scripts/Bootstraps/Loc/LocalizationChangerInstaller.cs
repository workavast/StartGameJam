using Zenject;

namespace StartGameJam.Scripts.Bootstraps.Loc
{
    public class LocalizationChangerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LocalizationChanger>().FromNew().AsSingle().NonLazy();
        }
    }
}