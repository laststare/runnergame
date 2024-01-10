using System.Collections.Generic;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public class LevelBuilderController : DisposableBase, IWorldMovable
    {
        public List<Transform> ObjectsToMove { get; set; }
        private readonly Queue<int> _loadedScenesIndexes = new Queue<int>();

        protected LevelBuilderController()
        {
            ObjectsToMove = new List<Transform>();
            LoadScene();
        }
        
        private async void LoadScene()
        {
            var randomSceneIndex = Random.Range(1, SceneManager.sceneCount);
            var asyncOperation = SceneManager.LoadSceneAsync(randomSceneIndex, LoadSceneMode.Additive);
            asyncOperation.allowSceneActivation = true;
            while (!asyncOperation.isDone)
            {
                await UniTask.Yield();
            }
            _loadedScenesIndexes.Enqueue(randomSceneIndex);
            var rootGameObjects = SceneManager.GetSceneByBuildIndex(randomSceneIndex).GetRootGameObjects();
            ObjectsToMove.Add(rootGameObjects[0].transform);
        }

        
    }
}