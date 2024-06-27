using UnityEngine;
using UnityEngine.UI;

namespace StartGameJam.Scripts.UI.Elements
{
    [RequireComponent(typeof(Button)), DisallowMultipleComponent]
    public class QuitButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Quit);
        }

        private static void Quit() 
            => Application.Quit();

        private void OnDestroy() 
            => _button.onClick.RemoveListener(Quit);
    }
}