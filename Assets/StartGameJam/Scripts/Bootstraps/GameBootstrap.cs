using StartGameJam.Scripts.Audio;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts
{
    public class GameBootstrap : MonoBehaviour
    {
        [Inject] private readonly AudioVolumeChanger _audioVolumeChanger;

        private void Start()
        {
            _audioVolumeChanger.StartInit();
        }
    }
}