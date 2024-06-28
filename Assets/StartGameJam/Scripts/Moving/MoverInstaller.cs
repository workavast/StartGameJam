using Zenject;

namespace StartGameJam.Scripts.Moving
{
    public class MoverInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var mover = FindObjectOfType<Mover>();
            Container.BindInterfacesAndSelfTo<Mover>().FromInstance(mover).AsSingle();
        }
    }
}