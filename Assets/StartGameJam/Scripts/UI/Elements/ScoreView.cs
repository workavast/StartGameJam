using StartGameJam.Scripts.ScoreCounting;
using TMPro;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Elements
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreView : MonoBehaviour
    {
        [Inject] private IScoreCounter _playerGameData;
     
        private TMP_Text _tmpText;
        
        private void Awake()
        {
            _tmpText = GetComponent<TMP_Text>();
            _playerGameData.OnChangeScore += UpdateView;

            UpdateView(_playerGameData.Score);
        }

        private void UpdateView(int newDifficulty)
        {
            _tmpText.text = newDifficulty.ToString();
        }

        private void OnDestroy()
        {
            if (_playerGameData != null)
                _playerGameData.OnChangeScore -= UpdateView;
        }
    }
}