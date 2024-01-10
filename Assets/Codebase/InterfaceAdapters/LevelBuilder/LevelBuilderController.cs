using System.Collections.Generic;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using External.Reactive;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public class LevelBuilderController : DisposableBase, ILevelBuilder
    {
        public Queue<Transform> PlatformsToMove { get; set; }
        public ReactiveProperty<Transform> LastSpawnedPlatform { get; set; }
        public ReactiveTrigger RemoveScene { get; set; }
        
        private readonly Queue<Scene> _loadedScenesIndexes = new();
        private bool _isAlive = true;

        protected LevelBuilderController()
        {
            PlatformsToMove = new Queue<Transform>();
            LastSpawnedPlatform = new ReactiveProperty<Transform>();
            RemoveScene = new ReactiveTrigger();
  
            SceneManager.sceneLoaded += OnSceneLoaded;
            
            LoadScene();
            CheckLastPlatformDistance();
        }
        
        private static void LoadScene()
        {
            var randomSceneIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            SceneManager.LoadSceneAsync(randomSceneIndex, LoadSceneMode.Additive);
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.buildIndex == 0) return;
            _loadedScenesIndexes.Enqueue(scene);
            var sceneRootObject = scene.GetRootGameObjects()[0].transform;
            PlatformsToMove.Enqueue(sceneRootObject);
            LastSpawnedPlatform.Value = sceneRootObject;
            CheckSceneToUnload();
        }
        
        private void CheckSceneToUnload()
        {
            if(PlatformsToMove.Count < 4)
                return;
            PlatformsToMove.Dequeue();
            SceneManager.UnloadSceneAsync(_loadedScenesIndexes.Dequeue());
        }

        private async void CheckLastPlatformDistance()
        {
            while (_isAlive)
            {
                if (LastSpawnedPlatform.Value != null)
                {
                    if (LastSpawnedPlatform.Value.position.x - LastSpawnedPlatform.Value.localScale.x / 2 <
                        LastSpawnedPlatform.Value.localScale.x / 4)
                        LoadScene();
                }
                await UniTask.Delay(1000);
            }
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _isAlive = false;
        }
    }
}