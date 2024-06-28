using System.Collections.Generic;
using Avastrad.DictionaryInspector;
using Avastrad.EnumValuesLibrary;
using Avastrad.PoolSystem;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.LevelBlocks
{
    public class LevelBlocksFactory : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<LevelBlockType, LevelBlockBase> prefabs;

        [Inject] private DiContainer _diContainer;
        
        private Pool<LevelBlockBase, LevelBlockType> _pool;
        
        private readonly Dictionary<LevelBlockType, Transform> _parents = new();
        private readonly List<LevelBlockType> _levelBlockTypes = new();
        
        private void Awake()
        {
            var types = EnumValuesTool.GetValues<LevelBlockType>();

            foreach (var type in types)
            {
                var parent = new GameObject()
                {
                    name = type.ToString(),
                    transform = { parent = transform}
                };
                _parents.Add(type, parent.transform);
                _levelBlockTypes.Add(type);
            }

            _pool = new Pool<LevelBlockBase, LevelBlockType>(Instantiate);
        }

        public LevelBlockBase CreateRandom()
        {
            var randomIndex = Random.Range(0, _levelBlockTypes.Count);
            return Create(_levelBlockTypes[randomIndex]);
        }
        
        public LevelBlockBase Create(LevelBlockType levelBlockType)
        {
            _pool.ExtractElement(levelBlockType, out var levelBlockBase);
            return levelBlockBase;
        }

        private LevelBlockBase Instantiate(LevelBlockType levelBlockType) 
            => _diContainer.InstantiatePrefab(prefabs[levelBlockType], _parents[levelBlockType])
                .GetComponent<LevelBlockBase>();
    }
}