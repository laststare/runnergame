using UnityEngine;

namespace Codebase.Data
{
    [CreateAssetMenu(fileName = "RunnerConfig", menuName = "GameData/RunnerConfig")]
    public class RunnerConfig : ScriptableObject
    {
        [SerializeField] private float jumpStrength;
        
        public float GetJumpStrength() => jumpStrength;
    }
}