using UnityEngine;

namespace Codebase.Data
{
    /// <summary>
    /// Конфиг с настройками эффектов, влияющих на перемещение персонажа
    /// </summary>
    [CreateAssetMenu(fileName = "BoosterConfig", menuName = "GameData/BoosterConfig")]
    public class BoosterConfig : ScriptableObject
    {
        [SerializeField] private float defaultEffectDuration;
        [SerializeField] private float speedUpMultiplier;
        [SerializeField] private float slowDownMultiplier;
        [SerializeField] private float flyHeight;
        
        public float GetDefaultEffectDuration => defaultEffectDuration;
        public float GetSpeedUpMultiplier => speedUpMultiplier;
        public float GetSlowDownMultiplier => slowDownMultiplier;
        public float GetFlyHeight => flyHeight;
    }
}