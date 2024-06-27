using StartGameJam.Scripts.Audio;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace StartGameJam.Scripts
{
    public class GameContextInstaller : MonoInstaller
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private GameBootstrap gameBootstrapPrefab;

        public override void InstallBindings()
        {
            BindAudioVolumeChanger();
            BindFpsCapChanger();
            BindGameBootstrap();
        }
        
        private void BindAudioVolumeChanger()
        {
            Container.Bind<AudioVolumeChanger>().FromNew().AsSingle()
                .WithArguments(audioMixer, PlayerData.PlayerData.Instance.VolumeSettings).NonLazy();
        }
            
        private void BindFpsCapChanger()
        {
            Container.Bind<FpsCapChanger>().FromNew().AsSingle()
                .WithArguments(PlayerData.PlayerData.Instance.FpsSettings).NonLazy();
        }
        
        private void BindGameBootstrap()
        {
            Container.InstantiatePrefab(gameBootstrapPrefab);
        }
    }
}