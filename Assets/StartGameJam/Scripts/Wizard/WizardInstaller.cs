using Zenject;

namespace StartGameJam.Scripts.Wizard
{
    public class WizardInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var wizard = FindObjectOfType<PlayerMovement>();

            Container.BindInterfacesAndSelfTo<PlayerMovement>().FromInstance(wizard).AsSingle();
        }
    }
}