using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace StartGameJam.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class DamageZone : MonoBehaviour, IResetable
    {
        [FormerlySerializedAs("activated")] [SerializeField] protected GameObject activatedAudio;
        [FormerlySerializedAs("deactivated")] [SerializeField] protected GameObject deactivatedAudio;
        
        [Inject] protected PlayerGameData _playerGameData;

        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IPlayer player)) 
                _playerGameData.TakeDamage();
        }

        public virtual void DeActivate()
        {
            gameObject.SetActive(false);
        }
        
        public virtual void Reset()
        {
            gameObject.SetActive(true);
        }

        protected void Play(GameObject audioClip)
        {
            Instantiate(audioClip);
        }
    }
}