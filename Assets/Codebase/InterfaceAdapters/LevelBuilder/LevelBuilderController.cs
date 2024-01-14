using System.Collections.Generic;
using Codebase.InterfaceAdapters.GameState;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using External.Reactive;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public class LevelBuilderController : DisposableBase, ILevelBuilder, ITriggerListener
    {
        public Queue<Transform> PlatformsToMove { get; set; }
        public ReactiveProperty<Transform> LastSpawnedPlatform { get; set; }
        
        public ReactiveEvent<ISceneTrigger[]> triggersToSubscribe { get; set; }
        public ReactiveEvent<ISceneTrigger[]> triggersToUnSubscribe { get; set; }
        
        private readonly Queue<SceneSet> _loadedSceneSets = new();
        private bool _isAlive = true;

        protected LevelBuilderController(IGameplayState iGameplayState)
        {
            PlatformsToMove = new Queue<Transform>();
            LastSpawnedPlatform = new ReactiveProperty<Transform>();
            triggersToSubscribe = new ReactiveEvent<ISceneTrigger[]>();
            triggersToUnSubscribe = new ReactiveEvent<ISceneTrigger[]>();
  
            SceneManager.sceneLoaded += OnSceneLoaded;
            
            iGameplayState.RestartGame.Subscribe(Restart).AddTo(_disposables);
            
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
            var sceneRootObject = scene.GetRootGameObjects()[0].transform;
            var triggers = sceneRootObject.GetComponentsInChildren<ISceneTrigger>();

            _loadedSceneSets.Enqueue(new SceneSet()
            {
                scene = scene,
                Triggers = triggers
            });
            
            PlatformsToMove.Enqueue(sceneRootObject);
            LastSpawnedPlatform.Value = sceneRootObject;
            triggersToSubscribe.Notify(triggers);
            CheckSceneToUnload();
        }
        
        private void CheckSceneToUnload()
        {
            if(PlatformsToMove.Count < 4)
                return;
            PlatformsToMove.Dequeue();
            var sceneSet = _loadedSceneSets.Dequeue();
            triggersToUnSubscribe.Notify(sceneSet.Triggers);
            SceneManager.UnloadSceneAsync(sceneSet.scene);
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

        private void Restart()
        {
            PlatformsToMove.Clear();
            
            int i = _loadedSceneSets.Count;
            while (i>0)
            {
                var sceneSet = _loadedSceneSets.Dequeue();
                triggersToUnSubscribe.Notify(sceneSet.Triggers);
                SceneManager.UnloadSceneAsync(sceneSet.scene);
                i--;
            }
            LoadScene();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _isAlive = false;
        }

       
    }
}