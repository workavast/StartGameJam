using System.Collections;
using UnityEngine;

namespace StartGameJam.Scripts.UI.Elements
{
    public class FadeElement : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float time;
        
        public void Hide()
        {
            canvasGroup.alpha = 0;
            StopAllCoroutines();
        }

        public void Show()
        {
            StopAllCoroutines();
            canvasGroup.alpha = 1;
            StartCoroutine(FadeHide());
        }

        private IEnumerator FadeHide()
        {
            var timer = 0f;
            while (timer < time)
            {
                yield return new WaitForEndOfFrame();
                timer += time * Time.deltaTime;

                canvasGroup.alpha = 1 - timer / time;
            }
        }
    }
}