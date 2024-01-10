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
        private readonly ILevelBuilder _levelBuilder;
        private Transform _lastPlatform;

        public LevelMoverController(ILevelBuilder levelBuilder)
        {
            _levelBuilder = levelBuilder;
            _levelBuilder.LastSpawnedPlatform.Subscribe(AddPlatform).AddTo(_disposables);
            _worldIsMoving = true;
            WorldMover();
        }

        private void AddPlatform(Transform platform)
        {
            if(platform == null)return;
            if (_lastPlatform == null)
                _lastPlatform = platform;
            else
            {
                platform.position = new Vector3(_lastPlatform.position.x + _lastPlatform.localScale.x / 2 + platform.localScale.x / 2,
                    platform.position.y, platform.position.z);
                _lastPlatform = platform;
            }
        }
        

        private async void WorldMover()
        {
            while (_isAlive)
            {
                if (_worldIsMoving)
                {
                    foreach (var transform in _levelBuilder.PlatformsToMove)
                    {
                        transform.Translate(-Vector3.right * Time.deltaTime * 6);
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