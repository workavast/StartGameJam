using System;
using UnityEngine;

namespace Avastrad.PoolSystem.Example
{
    public class Pool_ItemWithId : MonoBehaviour, PoolSystem.IPoolable<Pool_ItemWithId, Pool_Item_Ids>
    {
        [SerializeField] private bool useTimer;
        [SerializeField] [Range(0, 5)] private float time;
        [SerializeField] private bool useCountDestroy;
        [SerializeField] [Range(0, 5)] private int extractCount;


        private float _timer = 0;
        private int _extractCount = 0;

        public Pool_Item_Ids poolId;
        public Pool_Item_Ids PoolId => poolId;
        public event Action<Pool_ItemWithId> ReturnElementEvent;
        public event Action<Pool_ItemWithId> DestroyElementEvent;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        void Update()
        {
            if (useTimer)
            {
                _timer += Time.deltaTime;

                if (_timer > time) ReturnElementEvent?.Invoke(this);
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