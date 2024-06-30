using System;
using System.Collections;
using UnityEngine;

namespace StartGameJam.Scripts.Wizard.States
{
    public class DeathState : WizardStateBase
    {
        public override WizardState WizardState => WizardState.Death;
        public override event Action<WizardState> OnStateChange;

        private Coroutine _coroutine;

        public DeathState(PlayerMovement wizard) : base(wizard)
        {
        }

        public override void Enter()
        {
            Debug.Log("Death Enter");
            Wizard.Stop();
            _coroutine = Wizard.StartCoroutine(Death());
        }
        
        public override void Exit()
        {
            if(_coroutine != null)
                Wizard.StopCoroutine(_coroutine);
            Debug.Log("Death exit");
        }

        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
        }
        
        private IEnumerator Death()
        {
            Wizard.isDead = true;
            Wizard.playetAnim.Play("Death");
            var curTime = 0f;
            var deathLenght = Wizard.playetAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            while (deathLenght > curTime)
            {
                yield return new WaitForEndOfFrame();
                curTime += Time.deltaTime;
            }
            yield return new WaitForSeconds(0.25f);
            Wizard.OnDied?.Invoke();
        }
    }
}