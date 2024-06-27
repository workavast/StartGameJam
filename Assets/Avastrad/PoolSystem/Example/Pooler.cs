using System.Collections.Generic;
using UnityEngine;

namespace Avastrad.PoolSystem.Example
{
    public class Pooler : MonoBehaviour
    {
        [SerializeField] private GameObject poolItemPrefab;

        [Header("Pool")] [SerializeField] private bool expandable;
        [SerializeField] private bool reExtracted;
        [SerializeField] private int startSize;
        [SerializeField] private int maxSize;

        private Pool<Pool_Item> _pool;
        private IReadOnlyList<Pool_Item> BusyItems => _pool.BusyElements;
        private IReadOnlyList<Pool_Item> FreeItems => _pool.FreeElements;


        private void Awake()
        {
            _pool = new Pool<Pool_Item>(InstantiateFunc, expandable, reExtracted, startSize, maxSize);
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                _pool.ExtractElement(out Pool_Item item);

            if (Input.GetButtonDown("Fire2") && BusyItems.Count > 0)
                _pool.ReturnElement(BusyItems[0]);
        }

        private Pool_Item InstantiateFunc()
        {
            return Instantiate(poolItemPrefab).GetComponent<Pool_Item>();
        }
    }
}