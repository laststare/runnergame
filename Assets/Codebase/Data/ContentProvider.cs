using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Data
{
    [Serializable]
    public class ContentProvider: IContentProvider
    {
   
        [SerializeField] private ScenePrefabs scenePrefs;
        [SerializeField] private Settings settings;
        
        public Transform GetRunner() => scenePrefs.runner;
        public Scene GetRandomScene() => settings.sceneConfig.GetRandomScene();


        [Serializable]
        private class ScenePrefabs
        {
            public Transform runner;
        }
        
        [Serializable]
        private class Settings
        {
            public SceneConfig sceneConfig;
        }
        
    }
}