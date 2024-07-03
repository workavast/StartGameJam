using Zenject;

namespace StartGameJam.Scripts.Localization
{
    public class LocalizationChangerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LocalizationChanger>().FromNew().AsSingle().NonLazy();
        }
    }
}