using System.Collections;
using UnityEngine;

namespace StartGameJam.Scripts
{
    public class DamageZoneEnemy : DamageZone
    {
        private Animator enemyAnim;
        private bool isNoDamage = false;
        [SerializeField] private bool isNoHide = false;

        private void Start()
        {
            enemyAnim = GetComponentInChildren<Animator>();
        }
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (isNoDamage) return;

            Play(activatedAudio);
            base.OnTriggerEnter2D(other);
            enemyAnim.Play("Attack");
        }

        IEnumerator DeathAnim()
        {
            Play(deactivatedAudio);
            enemyAnim.Play("Death");
            var curTime = 0f;
            var deathLenght = enemyAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            while (deathLenght > curTime)
            {
                yield return new WaitForEndOfFrame();
                curTime += Time.deltaTime;
            }
            isNoDamage = false;
            if (!isNoHide)
            {
                gameObject.SetActive(false);
            }
        }
        public override void DeActivate()
        {
            isNoDamage = true;
            StartCoroutine(DeathAnim());
        }
    }
}
