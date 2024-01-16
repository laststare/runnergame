using Codebase.Data;
using Codebase.InterfaceAdapters.GameState;
using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelMover
{
    /// <summary>
    /// Контроллер движения платформ
    /// Получает платформы с подгруженных сцен
    /// Осуществляет состыковку и движения платформ
    /// </summary>
    public class LevelMoverController : DisposableBase, ILevelMover
    {
        public float LevelMoveSpeed { get; set; }
        private readonly ILevelBuilder _levelBuilder;
        private readonly ISettingsProvider _iSettingsProvider;
        private Transform _lastPlatform;

        public LevelMoverController(ILevelBuilder levelBuilder, ISettingsProvider iSettingsProvider, IGameplayState iGameplayState)
        {
            _iSettingsProvider = iSettingsProvider;
            _levelBuilder = levelBuilder;
            _levelBuilder.LastSpawnedPlatform.Subscribe(AddPlatform).AddTo(_disposables);
            iGameplayState.CurrentGameState.Subscribe(x =>
            {
                if (x == GameplayState.Gameplay)
                    ResetMoveSpeed();
            }).AddTo(_disposables);
            WorldMover();
        }

        /// <summary>
        /// Сброс скорости движения на дефолтную
        /// </summary>
        public void ResetMoveSpeed() => LevelMoveSpeed = _iSettingsProvider.GetDefaultWorldSpeed();

        /// <summary>
        /// Остановка движения
        /// </summary>
        public void StopMoving() => LevelMoveSpeed = 0;

        /// <summary>
        /// Добавление и состыковка новой платформы
        /// </summary>
        /// <param name="platform"></param>
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
        
        /// <summary>
        /// Движение платформ по оси Х
        /// </summary>
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