using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts
{
    public class DamageZone : MonoBehaviour, IResetable
    {
        [Inject] private PlayerGameData _playerGameData;

        private void OnTriggerEnter2D(Collider2D other)
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
    }
}