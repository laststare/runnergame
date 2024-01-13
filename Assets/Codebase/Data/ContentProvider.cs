using System;
using Codebase.InterfaceAdapters.UI;
using Codebase.Views;
using UnityEngine;

namespace Codebase.Data
{
    [Serializable]
    public class ContentProvider: IContentProvider
    {
   
        [SerializeField] private ScenePrefabs scenePrefs;
        [SerializeField] private Settings settings;
        [SerializeField] private UIViews uiViews;
        
        public Transform GetRunner() => scenePrefs.runner;
        public float GetDefaultWorldSpeed() => settings.worldConfig.GetDefaultWorldSpeed;
        public float GetDefaultEffectDuration() => settings.boosterConfig.GetDefaultEffectDuration;
        public float GetSpeedUpMultiplier() => settings.boosterConfig.GetSpeedUpMultiplier;
        public float GetSlowDownMultiplier() => settings.boosterConfig.GetSlowDownMultiplier;
        public float GetFlyHeight() => settings.boosterConfig.GetFlyHeight;
        public JumpButtonView GetJumpButtonView() => uiViews.jumpButtonView;

        [Serializable]
        private class UIViews
        {
            public JumpButtonView jumpButtonView;
        }

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