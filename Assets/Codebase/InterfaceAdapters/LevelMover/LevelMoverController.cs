using System.Collections.Generic;
using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelMover
{
    public class LevelMoverController : DisposableBase
    {
        private bool _isAlive = true;
        private readonly bool _worldIsMoving;
        private Transform _lastPlatform;
        private readonly Queue<Transform> _platformsToMove = new();

        public LevelMoverController(ILevelBuilder levelBuilder)
        {
            levelBuilder.LastSpawnedPlatform.Subscribe(AddPlatform).AddTo(_disposables);
            levelBuilder.DeletePlatform.Subscribe(RemovePlatform).AddTo(_disposables);
            _worldIsMoving = true;
            WorldMover();
        }

        private void AddPlatform(Transform platform)
        {
            if(platform == null)return;
            _platformsToMove.Enqueue(platform);
            if (_lastPlatform == null)
                _lastPlatform = platform;
            else
            {
                platform.position = new Vector3(_lastPlatform.position.x + _lastPlatform.localScale.x / 2 + platform.localScale.x / 2,
                    platform.position.y, platform.position.z);
                _lastPlatform = platform;
            }
        }

        private void RemovePlatform()
        {
            _platformsToMove.Dequeue();
        }

        private async void WorldMover()
        {
            while (_isAlive)
            {
                if (_worldIsMoving)
                {
                    foreach (var transform in _platformsToMove)
                    {
                        transform.Translate(-Vector3.right * Time.deltaTime * 3);
                    }
                }
                await UniTask.Yield();
            }
        }
        
        protected override void OnDispose()
        {
            _isAlive = false;
        }
    }
}