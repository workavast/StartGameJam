using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartGameJam.Scripts
{
    public class DamageZoneHive : DamageZone
    {

        private float duration = 0.5f; // длительность спуска
        private float startY;
        private void Start()
        {
            startY = transform.position.y;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
           StartCoroutine(HiveFall(other));
        }

        IEnumerator HiveFall(Collider2D other)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
            base.OnTriggerEnter2D(other);
            gameObject.SetActive(false);
        }

        public override void DeActivate()
        {
            gameObject.SetActive(false);
        }
    }
}
