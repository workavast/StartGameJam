using System.Collections;
using UnityEngine;

namespace StartGameJam.Scripts
{
    public class DamageZoneHive : DamageZone
    {
        private float duration = 0.5f; // ������������ ������
        private float startY;
        [SerializeField] private Animator blastAnim;
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

            Play(activatedAudio);
            
            base.OnTriggerEnter2D(other);
            gameObject.SetActive(false);
        }

        IEnumerator DeathAnim()
        {
            blastAnim.Play("Blast");
            var curTime = 0f;
            var deathLenght = blastAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            while (deathLenght > curTime)
            {
                yield return new WaitForEndOfFrame();
                curTime += Time.deltaTime;
            }
          //  isNoDamage = false;
           // if (!isNoHide)
          //  {
                gameObject.SetActive(false);
           // }
        }

        public override void DeActivate()
        {
            Play(deactivatedAudio);
            // blastAnim.Play("Blast");
            //  gameObject.SetActive(false);
            StartCoroutine(DeathAnim());
        }
    }
}
