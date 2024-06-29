using Zenject;

namespace StartGameJam.Scripts.ScoreCounting
{
    public class ScoreCounterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScoreCounter>().FromNew().AsSingle().NonLazy();
        }
    }
}