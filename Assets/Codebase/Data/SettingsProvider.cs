using System;
using UnityEngine;

namespace Codebase.Data
{
    [Serializable]
    public class SettingsProvider : ISettingsProvider
    {
        
        [Serializable]
        private class Settings
        {
            public WorldConfig worldConfig;
            public BoosterConfig boosterConfig;
            public RunnerConfig runnerConfig;
        }
        [SerializeField] 
        private Settings settings;
        
        public float GetDefaultWorldSpeed() => settings.worldConfig.GetDefaultWorldSpeed;
        public float GetDefaultEffectDuration() => settings.boosterConfig.GetDefaultEffectDuration;
        public float GetSpeedUpMultiplier() => settings.boosterConfig.GetSpeedUpMultiplier;
        public float GetSlowDownMultiplier() => settings.boosterConfig.GetSlowDownMultiplier;
        public float GetFlyHeight() => settings.boosterConfig.GetFlyHeight;
        public float GetJumpStrength() => settings.runnerConfig.GetJumpStrength();
    }
}