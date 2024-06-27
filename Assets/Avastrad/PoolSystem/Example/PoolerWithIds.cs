using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Avastrad.PoolSystem.Example
{
    public enum Pool_Item_Ids
    {
        First,
        Second,
        Third
    }

    [Serializable]
    public struct DictionaryCell<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }

    public class PoolerWithIds : MonoBehaviour
    {
        [SerializeField] private GameObject poolItemPrefab;

        [Header("Pool")] [SerializeField] private bool expandableId;
        [SerializeField] private bool expandableElements;
        [SerializeField] private bool reExtracted;
        [SerializeField] private int capacityOfIds;
        [SerializeField] private List<DictionaryCell<Pool_Item_Ids, int>> capacityElements;
        [SerializeField] private List<DictionaryCell<Pool_Item_Ids, int>> initialElementsCounts;

        private Pool<Pool_ItemWithId, Pool_Item_Ids> _pool;
        private IReadOnlyDictionary<Pool_Item_Ids, IReadOnlyList<Pool_ItemWithId>> BusyItems => _pool.BusyElements;
        private IReadOnlyDictionary<Pool_Item_Ids, IReadOnlyList<Pool_ItemWithId>> FreeItems => _pool.FreeElements;


        private void Awake()
        {
            Dictionary<Pool_Item_Ids, int> _capacityElements = new Dictionary<Pool_Item_Ids, int>();
            foreach (var element in capacityElements)
                _capacityElements.Add(element.Key, element.Value);

            Dictionary<Pool_Item_Ids, int> _initialElementsCounts = new Dictionary<Pool_Item_Ids, int>();
            foreach (var element in initialElementsCounts)
                _initialElementsCounts.Add(element.Key, element.Value);

            _pool = new Pool<Pool_ItemWithId, Pool_Item_Ids>(InstantiateFunc, expandableId, expandableElements,
                reExtracted,
                capacityOfIds, new ReadOnlyDictionary<Pool_Item_Ids, int>(_capacityElements),
                new ReadOnlyDictionary<Pool_Item_Ids, int>(_initialElementsCounts));
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                _pool.ExtractElement(Pool_Item_Ids.First, out Pool_ItemWithId itemWithId);
            if (Input.GetKeyDown(KeyCode.W))
                _pool.ExtractElement(Pool_Item_Ids.Second, out Pool_ItemWithId itemWithId);
            if (Input.GetKeyDown(KeyCode.E))
                _pool.ExtractElement(Pool_Item_Ids.Third, out Pool_ItemWithId itemWithId);

            if (Input.GetKeyDown(KeyCode.A) && BusyItems.ContainsKey(Pool_Item_Ids.First) &&
                BusyItems[Pool_Item_Ids.First].Count > 0)
                _pool.ReturnElement(BusyItems[Pool_Item_Ids.First][0]);
            if (Input.GetKeyDown(KeyCode.S) && BusyItems.ContainsKey(Pool_Item_Ids.Second) &&
                BusyItems[Pool_Item_Ids.Second].Count > 0)
                _pool.ReturnElement(BusyItems[Pool_Item_Ids.Second][0]);
            if (Input.GetKeyDown(KeyCode.D) && BusyItems.ContainsKey(Pool_Item_Ids.Third) &&
                BusyItems[Pool_Item_Ids.Third].Count > 0)
                _pool.ReturnElement(BusyItems[Pool_Item_Ids.Third][0]);
        }

        private Pool_ItemWithId InstantiateFunc(Pool_Item_Ids id)
        {
            Pool_ItemWithId itemWithId = Instantiate(poolItemPrefab).GetComponent<Pool_ItemWithId>();
            itemWithId.poolId = id;
            return itemWithId;
        }
    }
}