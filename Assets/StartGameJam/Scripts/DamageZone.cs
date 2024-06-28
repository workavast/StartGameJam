using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts
{
    public class DamageZone : MonoBehaviour
    {
        [Inject] private PlayerGameData _playerGameData;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IPlayer player)) 
                _playerGameData.TakeDamage();
        }
    }
}