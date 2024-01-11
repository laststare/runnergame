using System;
using UnityEngine;

namespace Codebase.Data
{
    [Serializable]
    public class ContentProvider: IContentProvider
    {
   
        [SerializeField] private ScenePrefabs scenePrefs;
        [SerializeField] private Settings settings;
        
        public Transform GetRunner() => scenePrefs.runner;
        public float GetDefaultWorldSpeed() => settings.worldConfig.GetDefaultWorldSpeed;
        public float GetDefaultEffectDuration() => settings.boosterConfig.GetDefaultEffectDuration;
        public float GetSpeedUpMultiplier() => settings.boosterConfig.GetSpeedUpMultiplier;
        public float GetSlowDownMultiplier() => settings.boosterConfig.GetSlowDownMultiplier;


        [Serializable]
        private class ScenePrefabs
        {
            public Transform runner;
        }
        
        [Serializable]
        private class Settings
        {
            public WorldConfig worldConfig;
            public BoosterConfig boosterConfig;
        }
        
    }
}