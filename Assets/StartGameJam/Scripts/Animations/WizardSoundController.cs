using System;
using UnityEngine;

namespace StartGameJam.Scripts.Animations
{
    [RequireComponent(typeof(AudioSource))]
    public class WizardSoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip attack;
        [SerializeField, Range(0,1)] private float attackVolume;
        [Space]
        [SerializeField] private AudioClip hit;
        [SerializeField, Range(0,1)] private float hitVolume;
        [Space]
        [SerializeField] private AudioClip death;
        [SerializeField, Range(0,1)] private float deathVolume;

        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void PlayAttack()
        {
            _audioSource.clip = attack;
            _audioSource.volume = attackVolume;
            _audioSource.Play();
        }
        
        private void PlayHit()
        {
            _audioSource.clip = hit;
            _audioSource.volume = hitVolume;
            _audioSource.Play();
        }
        
        private void PlayDeath()
        {
            _audioSource.clip = death;
            _audioSource.volume = deathVolume;
            _audioSource.Play();
        }
    }
}