using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Elements
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Heart heartPrefab;

        [Inject] private PlayerGameData _playerGameData;

        private List<Heart> _hearts;
        
        private void Start()
        {
            var hearts = GetComponentsInChildren<Heart>();
            int heartsCount = hearts.Length;
            
            for (int i = 0; i < heartsCount - _playerGameData.HealthPoints.MaxValue; i++) 
                Destroy(hearts[i].gameObject);

            _hearts = new List<Heart>(hearts);
            for (int i = heartsCount; i < _playerGameData.HealthPoints.MaxValue; i++)
            {
                var heart = Instantiate(heartPrefab, transform); 
                _hearts.Add(heart);
            }

            _playerGameData.HealthPoints.OnChange += UpdateHearts;
        }

        private void UpdateHearts()
        {
            var heartIndex = 0;
            
            for (heartIndex = 0; heartIndex < _playerGameData.HealthPoints.CurrentValue; heartIndex++)
                _hearts[heartIndex].Show();

            for (; heartIndex < _playerGameData.HealthPoints.MaxValue; heartIndex++)
                _hearts[heartIndex].Hide();
        }

        private void OnDestroy()
        {
            _playerGameData.HealthPoints.OnChange -= UpdateHearts;
        }
    }
}