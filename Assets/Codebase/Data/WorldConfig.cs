using UnityEngine;

namespace Codebase.Data
{
    /// <summary>
    /// Конфиг с настройками игрового мира
    /// </summary>
    [CreateAssetMenu(fileName = "WorldConfig", menuName = "GameData/WorldConfig")]
    public class WorldConfig : ScriptableObject
    {
        [SerializeField] private float defaultWorldSpeed;
        
        public float GetDefaultWorldSpeed => defaultWorldSpeed;
    }
}