using System;
using Avastrad.PoolSystem;
using UnityEngine;

namespace StartGameJam.Scripts.LevelBlocks
{
    public class LevelBlockBase : MonoBehaviour, IPoolable<LevelBlockBase, LevelBlockType>
    {
        [SerializeField] private LevelBlockType levelBlockType;
        [SerializeField] private Transform lefPoint;
        [SerializeField] private Transform rightPoint;

        public Vector3 LeftPoint => lefPoint.position;
        public Vector3 RightPoint => rightPoint.position;
        
        public LevelBlockType PoolId => levelBlockType;

        public event Action<LevelBlockBase> ReturnElementEvent;
        public event Action<LevelBlockBase> DestroyElementEvent;

        public void RemoveBlock() 
            => ReturnElementEvent?.Invoke(this);
        
        public void OnElementExtractFromPool()
        {
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