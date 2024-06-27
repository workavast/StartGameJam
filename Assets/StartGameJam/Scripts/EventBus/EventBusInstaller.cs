using Zenject;

namespace StartGameJam.Scripts.EventBus
{
    public class EventBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Avastrad.EventBusFramework.EventBus>().FromNew().AsSingle();
        }
    }
}