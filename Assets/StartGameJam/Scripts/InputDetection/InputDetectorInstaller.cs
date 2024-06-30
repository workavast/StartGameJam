using Zenject;

namespace StartGameJam.Scripts.InputDetection
{
    public class InputDetectorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputDetector>().FromNew().AsSingle().NonLazy();
        }
    }
}