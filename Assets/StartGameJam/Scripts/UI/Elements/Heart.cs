using UnityEngine;

namespace StartGameJam.Scripts.UI.Elements
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private GameObject fill;
        
        public void Show()
        {
            fill.SetActive(true);
        }

        public void Hide()
        {
            fill.SetActive(false);
        }
    }
}