using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StartGameJam.Scripts.Wizard.States
{
    public class AttackState : WizardStateBase
    {
        public override WizardState WizardState => WizardState.Attack;
        public override event Action<WizardState> OnStateChange;

        private Coroutine _coroutine;

        public AttackState(PlayerMovement wizard) : base(wizard)
        {
        }

        public override void Enter()
        {
            Wizard.playetAnim.Play("Attack");
            Wizard.Stop();
            _coroutine = Wizard.StartCoroutine(DestroyDangerous(0.6f));
        }

        public override void Exit()
        {
            if(_coroutine != null)
                Wizard.StopCoroutine(_coroutine);
        }
        
        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
        }
        
        private IEnumerator DestroyDangerous(float delay)
        {
            yield return new WaitForSeconds(delay);
        
            var dangerObjects = Object.FindObjectsByType<DamageZone>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            if (dangerObjects.Length == 0)
                yield break;
        
            DamageZone nearestDanger = null;
            float minDistance = Mathf.Infinity;
            Vector3 currentPosition = Wizard.transform.position;
            foreach (var dangerObject in dangerObjects)
            {
                float distance = Vector3.Distance(currentPosition, dangerObject.transform.position);
                if (dangerObject.transform.position.x >= Wizard.transform.position.x && distance < minDistance)
                {
                    minDistance = distance;
                    nearestDanger = dangerObject;
                }
            }
    
            if (nearestDanger != null)
                nearestDanger.DeActivate();
            
            OnStateChange?.Invoke(WizardState.Run);
        }
    }
}