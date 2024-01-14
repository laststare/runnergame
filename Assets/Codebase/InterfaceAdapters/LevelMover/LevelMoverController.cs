using Codebase.Data;
using Codebase.InterfaceAdapters.GameState;
using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelMover
{
    public class LevelMoverController : DisposableBase, ILevelMover
    {
        public float LevelMoveSpeed { get; set; }
        
        private readonly ILevelBuilder _levelBuilder;
        private readonly IContentProvider _iContentProvider;
        private Transform _lastPlatform;

        public LevelMoverController(ILevelBuilder levelBuilder, IContentProvider iContentProvider, IGameplayState iGameplayState)
        {
            _iContentProvider = iContentProvider;
            _levelBuilder = levelBuilder;
            _levelBuilder.LastSpawnedPlatform.Subscribe(AddPlatform).AddTo(_disposables);
            iGameplayState.CurrentGameState.Subscribe(x =>
            {
                if (x == GameplayState.Gameplay)
                    ResetMoveSpeed();
            }).AddTo(_disposables);
            WorldMover();
        }
        
        public void ResetMoveSpeed() => LevelMoveSpeed = _iContentProvider.GetDefaultWorldSpeed();

        public void StopMoving() => LevelMoveSpeed = 0;

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
            while (IsAlive)
            {
                foreach (var transform in _levelBuilder.PlatformsToMove)
                {
                    transform.Translate(-Vector3.right * Time.deltaTime * LevelMoveSpeed);
                }
                await UniTask.Yield();
            }
        }

    }
}