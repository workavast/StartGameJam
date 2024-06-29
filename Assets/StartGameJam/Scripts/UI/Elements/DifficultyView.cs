using TMPro;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Elements
{
    [RequireComponent(typeof(TMP_Text))]
    public class DifficultyView : MonoBehaviour
    {
        [Inject] private PlayerGameData _playerGameData;
     
        private TMP_Text _tmpText;
        
        private void Awake()
        {
#if !UNITY_EDITOR
            Destroy(gameObject);
            return;
#endif
            
            _tmpText = GetComponent<TMP_Text>();
            _playerGameData.OnChangeDifficulty += UpdateView;

            UpdateView(_playerGameData.Difficulty);
        }

        private void UpdateView(int newDifficulty)
        {
            _tmpText.text = newDifficulty.ToString();
        }

        private void OnDestroy()
        {
            _playerGameData.OnChangeDifficulty -= UpdateView;
        }
    }
}