using System.Collections.Generic;
using Codebase.Utilities;
using External.Reactive;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public class LevelBuilderController : DisposableBase, ILevelBuilder
    {
        public ReactiveProperty<Transform> LastSpawnedPlatform { get; set; }
        public ReactiveTrigger DeletePlatform { get; set; }
        private readonly Queue<Scene> _loadedScenesIndexes = new();

        protected LevelBuilderController()
        {
            LastSpawnedPlatform = new ReactiveProperty<Transform>();
            DeletePlatform = new ReactiveTrigger();
            SceneManager.sceneLoaded += OnSceneLoaded;
            LoadScene();
            
            Observable.EveryUpdate() 
                .Where(_ => Input.GetKeyDown(KeyCode.Space)) 
                .Subscribe (x => { 
                    LoadScene(); 
                }).AddTo (_disposables);
            
            Observable.EveryUpdate() 
                .Where(_ => Input.GetKeyDown(KeyCode.Z)) 
                .Subscribe (x => { 
                    UnLoadScene(); 
                }).AddTo (_disposables);
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
            LastSpawnedPlatform.Value = scene.GetRootGameObjects()[0].transform;
        }

        private void UnLoadScene()
        {
            DeletePlatform.Notify();
            SceneManager.UnloadSceneAsync(_loadedScenesIndexes.Dequeue());
        }
        
    }
}