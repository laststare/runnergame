using System;
using Codebase.Views.UI;
using UnityEngine;

namespace Codebase.Data
{
    [Serializable]
    public class ContentProvider: IContentProvider
    {
   
        [SerializeField] private ScenePrefabs scenePrefs;
        [SerializeField] private UIViews uiViews;
        
        public Transform GetRunner() => scenePrefs.runner;
        public JumpButtonView GetJumpButtonView() => uiViews.jumpButtonView;
        public MainMenuView GetMainMenuView() => uiViews.mainMenuView;

        [Serializable]
        private class UIViews
        {
            public JumpButtonView jumpButtonView;
            public MainMenuView mainMenuView;
        }

        [Serializable]
        private class ScenePrefabs
        {
            public Transform runner;
        }
        
        
        
    }
}