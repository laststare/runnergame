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
    /// <summary>
    /// Загрузчик уровней
    /// Реализует асинхронную загрузку и выгрузку сцен
    /// Регистрирует и отдаёт платформы и триггеры с каждой сцены
    /// </summary>
    public class LevelBuilderController : DisposableBase, ILevelBuilder, ITriggerListener
    {
        public Queue<Transform> PlatformsToMove { get; set; } = new();
        public ReactiveProperty<Transform> LastSpawnedPlatform { get; set; } = new();
        public ReactiveEvent<ITrigger[]> triggersToSubscribe { get; } = new();
        public ReactiveEvent<ITrigger[]> triggersToUnSubscribe { get; } = new();
        
        private readonly Queue<SceneSet> _loadedSceneSets = new();
        private bool _isAlive = true;

        protected LevelBuilderController(IGameplayState iGameplayState)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            iGameplayState.RestartGame.Subscribe(Restart).AddTo(_disposables);
            LoadScene();
            CheckLastPlatformDistance();
        }
        
        /// <summary>
        /// Подгрузка сцены
        /// </summary>
        private static void LoadScene()
        {
            var randomSceneIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            SceneManager.LoadSceneAsync(randomSceneIndex, LoadSceneMode.Additive);
        }
        
        /// <summary>
        /// Получение платформы и триггеров с подгруженной сцены
        ///
        /// Это всего один из вариантов взаимодействия с объектами на сцене, так же можно реализовать:
        /// 1. расстановку шаблонных объектов и деле замену их на префабы и подключение подписок
        /// 2. составления конфига с позициями объектоа и спавн префабов в эти точки с подключением подписок
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.buildIndex == 0) return;
            var sceneRootObject = scene.GetRootGameObjects()[0].transform;
            var triggers = sceneRootObject.GetComponentsInChildren<ITrigger>();

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
        
        /// <summary>
        /// Проверка не необходимость выгрузки сцены
        /// с последующей выгрузкой
        /// </summary>
        private void CheckSceneToUnload()
        {
            if(PlatformsToMove.Count < 4)
                return;
            PlatformsToMove.Dequeue();
            var sceneSet = _loadedSceneSets.Dequeue();
            triggersToUnSubscribe.Notify(sceneSet.Triggers);
            SceneManager.UnloadSceneAsync(sceneSet.scene);
        }

        /// <summary>
        /// Регулярная проверка расстояния до последней платформы
        /// </summary>
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

        /// <summary>
        /// Перезапуск уровня
        /// </summary>
        private void Restart()
        {
            PlatformsToMove.Clear();
            var i = _loadedSceneSets.Count;
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