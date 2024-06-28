using UnityEngine;

namespace StartGameJam.Scripts.Core
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "StartGameJam/Configs/" + nameof(GameConfig))]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField, Min(1)] public int HeartsCount { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 2;
    }
}