using System;
using UnityEngine;

namespace Avastrad.PoolSystem.Example
{
    public class Pool_Item : MonoBehaviour, PoolSystem.IPoolable<Pool_Item>
    {
        [SerializeField] private bool useTimer;
        [SerializeField] [Range(0,5)] private float time;
        [SerializeField] private bool useCountDestroy;
        [SerializeField] [Range(0,5)] private int extractCount;
    
        private float _timer = 0;
        private int _extractCount = 0;
    
        public event Action<Pool_Item> ReturnElementEvent;
        public event Action<Pool_Item> DestroyElementEvent;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        void Update()
        {
            if (useTimer)
            {
                _timer += Time.deltaTime;
        
                if(_timer > time) ReturnElementEvent?.Invoke(this);
            }

            if (useCountDestroy && _extractCount >= extractCount) Destroy(gameObject);
        }
    
        public void OnElementExtractFromPool()
        {
            _extractCount++;
            _timer = 0;
            Debug.Log("Activated");
            gameObject.SetActive(true);
        }
    
        public void OnElementReturnInPool()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            DestroyElementEvent?.Invoke(this);
        }
    }   
}
