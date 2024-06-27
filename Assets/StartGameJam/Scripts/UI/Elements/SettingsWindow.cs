using UnityEngine;

namespace StartGameJam.Scripts.UI.Elements
{
    public class SettingsWindow : MonoBehaviour
    {
        public void Show() 
            => gameObject.SetActive(true);

        public void Hide() 
            => gameObject.SetActive(false);
    }
}