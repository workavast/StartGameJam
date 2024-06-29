using StartGameJam.Scripts.ScoreCounting;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Elements
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private NewRecordBlock newRecordBlock;
        [SerializeField] private NonNewRecordBlock nonNewRecordBlock;

        [Inject] private IScoreCounter _scoreCounter;
        
        public void Show()
        {
            gameObject.SetActive(true);

            if (_scoreCounter.Score > _scoreCounter.PrevScoreRecord)
            {
                newRecordBlock.Show();
                nonNewRecordBlock.Hide();
            }
            else
            {
                nonNewRecordBlock.Show();
                newRecordBlock.Hide();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}