using StartGameJam.Scripts.ScoreCounting;
using TMPro;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Elements
{
    public class NewRecordBlock : MonoBehaviour
    {
        [SerializeField] private TMP_Text recordScore;
            
        [Inject] private IScoreCounter _scoreCounter;
        
        public void Show()
        {
            recordScore.text = _scoreCounter.Score.ToString();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}