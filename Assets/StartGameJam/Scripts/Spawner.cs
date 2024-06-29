using System;
using System.Collections.Generic;
using System.Linq;
using Avastrad.EnumValuesLibrary;
using StartGameJam.Scripts.LevelBlocks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StartGameJam.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float size;
        [SerializeField] private LevelBlocksFactory levelBlocksFactory;
        
        public Vector2 LeftPoint => transform.position - Vector3.right * size;
        public Vector2 RightPoint => transform.position + Vector3.right * size;
        
        private readonly List<LevelBlockBase> _activeBlocks = new(8);
        private readonly List<LevelBlockType> _levelBlockTypes = new();

        private void Awake()
        {
            var types = EnumValuesTool.GetValues<LevelBlockType>();
            foreach (var type in types) 
                _levelBlockTypes.Add(type);
        }

        private void Start()
        {
            var currentRightPoint = transform.position - Vector3.right * size;

            int interationCounter = 0;
            while (currentRightPoint.x <= transform.position.x + size)
            {
                if (interationCounter >= 100)
                    throw new Exception("TOO MUCH");
                
                var road = levelBlocksFactory.Create(LevelBlockType.Road);
                CalculatePosition(currentRightPoint, road);
                currentRightPoint = road.RightPoint;
                _activeBlocks.Add(road);
            }
        }

        private void Update()
        {
            if (_activeBlocks.First().RightPoint.x < LeftPoint.x)
            {
                _activeBlocks.First().RemoveBlock();
                _activeBlocks.RemoveAt(0);
            }

            if (_activeBlocks.Last().RightPoint.x <= RightPoint.x)
            {
                var possibleBlocks = _levelBlockTypes.ToList();
                possibleBlocks.Remove(_activeBlocks.Last().PoolId);
                
                var randomIndex = Random.Range(0, possibleBlocks.Count);
                var newBlockType = possibleBlocks[randomIndex];
                
                var block = levelBlocksFactory.Create(newBlockType);
                CalculatePosition(_activeBlocks.Last().RightPoint, block);
                _activeBlocks.Add(block);
            }
        }

        private void CalculatePosition(Vector2 rightPoint, LevelBlockBase levelBlockBase)
        {
            Vector2 distanceBetweenLeftPointAndCenter = levelBlockBase.transform.position - levelBlockBase.LeftPoint;
            var spawnPos = rightPoint + Vector2.right * distanceBetweenLeftPointAndCenter.x - Vector2.down * distanceBetweenLeftPointAndCenter.y;
            levelBlockBase.transform.position = spawnPos;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position - Vector3.up/4,  Vector3.up/2 + Vector3.right * size * 2);
        }
    }
}