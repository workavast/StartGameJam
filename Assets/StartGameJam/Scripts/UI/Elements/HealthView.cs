using System.Collections.Generic;
using System.Linq;
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
            var hearts = GetComponentsInChildren<Heart>().ToList();
            int heartsCount = hearts.Count;

            var counter = 0;
            for (int i = 0; i < heartsCount - _playerGameData.HealthPoints.MaxValue; i++)
            {
                counter++;
                Destroy(hearts[i].gameObject);
            }

            for (int i = counter-1; i >= 0; i--)
            {
                hearts.RemoveAt(i);
            }            
            
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
            if (_playerGameData != null)
                _playerGameData.HealthPoints.OnChange -= UpdateHearts;
        }
    }
}