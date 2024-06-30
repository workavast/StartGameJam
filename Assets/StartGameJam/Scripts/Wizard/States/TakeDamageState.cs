using System;
using System.Collections;
using UnityEngine;

namespace StartGameJam.Scripts.Wizard.States
{
    public class TakeDamageState : WizardStateBase
    {
        public override WizardState WizardState => WizardState.TakeDamage;
        public override event Action<WizardState> OnStateChange;

        private Coroutine _coroutine;
        
        public TakeDamageState(PlayerMovement wizard) : base(wizard)
        {
        }

        public override void Enter()
        {
            Debug.Log("TakeDamageState Enter");
            Wizard.Stop();
            _coroutine = Wizard.StartCoroutine(PlayHitAnim());
        }

        public override void Exit()
        {
            if(_coroutine != null)
                Wizard.StopCoroutine(_coroutine);
            Debug.Log("TakeDamageState exit");
        }

        public override void Update()
        {
        }
        
        public override void FixedUpdate()
        {
        }
        
        private IEnumerator PlayHitAnim()
        {
            Wizard.playetAnim.Play("Hit");
            var curTime = 0f;
            var deathLenght = Wizard.playetAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            while (deathLenght > curTime)
            {
                yield return new WaitForEndOfFrame();
                curTime += Time.deltaTime;
            }

            OnStateChange?.Invoke(WizardState.Run);
        }
    }
}