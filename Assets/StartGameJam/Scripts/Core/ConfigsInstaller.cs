using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.Core
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private ScriptableObject[] scriptableObjects;
        
        public override void InstallBindings()
        {
            foreach (var scriptableObject in scriptableObjects)
            {
                var type = scriptableObject.GetType();
                Container.Bind(type).FromInstance(scriptableObject).AsSingle();
            }
        }
    }
}