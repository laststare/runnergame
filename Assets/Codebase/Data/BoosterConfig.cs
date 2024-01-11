using UnityEngine;

namespace Codebase.Data
{
    [CreateAssetMenu(fileName = "BoosterConfig", menuName = "GameData/BoosterConfig")]
    public class BoosterConfig : ScriptableObject
    {
        [SerializeField] private float defaultEffectDuration;
        [SerializeField] private float speedUpMultiplier;
        [SerializeField] private float slowDownMultiplier;
        
        public float GetDefaultEffectDuration => defaultEffectDuration;
        public float GetSpeedUpMultiplier => speedUpMultiplier;
        public float GetSlowDownMultiplier => slowDownMultiplier;
    }
}