using UnityEngine;

namespace Codebase.Data
{
    /// <summary>
    /// Конфиг с настройками персонажа
    /// </summary>
    [CreateAssetMenu(fileName = "RunnerConfig", menuName = "GameData/RunnerConfig")]
    public class RunnerConfig : ScriptableObject
    {
        [SerializeField] private float jumpStrength;
        
        public float GetJumpStrength() => jumpStrength;
    }
}