using UnityEngine;

namespace Avastrad.DictionaryInspector.Example
{
    public class SerializableDictionaryExample : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<int, int> serializableDictionary;

        private void Awake()
        {
            if (serializableDictionary.ContainsKey(1))
            {
                Debug.Log(serializableDictionary[1]);
            }
            if (serializableDictionary.ContainsKey(2))
            {
                Debug.Log("2");
            }
            if (serializableDictionary.ContainsKey(3))
            {
                Debug.Log("3");
            }
            if (serializableDictionary.ContainsKey(4))
            {
                Debug.Log("4");
            }
            if (serializableDictionary.ContainsKey(51))
            {
                Debug.Log("51");
            }
            if (serializableDictionary.ContainsKey(5536))
            {
                Debug.Log("5536");
            }
        
        }

        [ContextMenu("Add")]
        private void Add() => serializableDictionary.Add(7, 7);
    
    
        [ContextMenu("Remove")]
        private void Remove() => serializableDictionary.Remove(1);

    
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Application.Quit();
            }
        }
    }
}
