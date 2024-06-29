using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartGameJam.Scripts
{
    public class DamageZoneSpikes : DamageZone
    {

        private float duration = 0.7f; // длительность спуска
        IEnumerator HideSpike()
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = endPosition;
            gameObject.SetActive(false);
        }

        public override void DeActivate()
        {
            StartCoroutine(HideSpike());
        }
    }
}
