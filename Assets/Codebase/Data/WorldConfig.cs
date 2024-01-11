using UnityEngine;

namespace Codebase.Data
{
    [CreateAssetMenu(fileName = "WorldConfig", menuName = "GameData/WorldConfig")]
    public class WorldConfig : ScriptableObject
    {
        [SerializeField] private float defaultWorldSpeed;
        
        public float GetDefaultWorldSpeed => defaultWorldSpeed;
    }
}