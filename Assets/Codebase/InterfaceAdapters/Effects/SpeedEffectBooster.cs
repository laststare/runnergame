using Codebase.Data;
using Codebase.InterfaceAdapters.GameState;
using Codebase.InterfaceAdapters.LevelMover;
using Codebase.InterfaceAdapters.TriggerListener;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Codebase.InterfaceAdapters.Effects
{
    /// <summary>
    /// Контроллер эффектов изменения скорости
    /// Регулирует эффекты ускорения и замедления через изменение скорости движения платформ
    /// Суммируется только сила разных эффектов
    /// </summary>
    public class SpeedEffectBooster :  DisposableBase
    {
        private readonly ILevelMover _iLevelMover;
        private readonly ISettingsProvider _iSettingsProvider;
        private readonly ITriggerReaction _iTriggerReaction;
        private readonly IGameplayState _iGameplayState;
        
        public SpeedEffectBooster(ITriggerReaction iTriggerReaction, ILevelMover iLevelMover, ISettingsProvider iSettingsProvider, IGameplayState iGameplayState)
        {
            _iLevelMover = iLevelMover;
            _iSettingsProvider = iSettingsProvider;
            _iTriggerReaction = iTriggerReaction;
            _iGameplayState = iGameplayState;
            
            iTriggerReaction.TriggerReaction.SubscribeWithSkip(x =>
            {
                if (x.TriggerType == TriggerType.SpeedUpCoin)
                    SpeedUpEffect(x);
            }).AddTo(_disposables);
            
            iTriggerReaction.TriggerReaction.SubscribeWithSkip(x =>
            {
                if (x.TriggerType == TriggerType.SlowDownCoin)
                    SlowDownEffect(x);
            }).AddTo(_disposables);
        }

        /// <summary>
        /// Ускорение
        /// Если игрок уже имеет этот эффект, действие пропускается
        /// </summary>
        /// <param name="iTrigger"></param>
        private void SpeedUpEffect(ITrigger iTrigger)
        {
            iTrigger.GetTransform.gameObject.SetActive(false);
            if (_iTriggerReaction.ActualTrigger == iTrigger.TriggerType)
                return;
            _iTriggerReaction.ActualTrigger = iTrigger.TriggerType;
            _iLevelMover.LevelMoveSpeed *= _iSettingsProvider.GetSpeedUpMultiplier();
            FinishEffect(_iSettingsProvider.GetDefaultEffectDuration(), iTrigger.TriggerType);
        }

        /// <summary>
        /// Замедление
        /// Если игрок уже имеет этот эффект, действие пропускается
        /// </summary>
        /// <param name="iTrigger"></param>
        private void SlowDownEffect(ITrigger iTrigger)
        {
            iTrigger.GetTransform.gameObject.SetActive(false);
            if (_iTriggerReaction.ActualTrigger == iTrigger.TriggerType)
                return;
            _iTriggerReaction.ActualTrigger = iTrigger.TriggerType;
            _iLevelMover.LevelMoveSpeed /= _iSettingsProvider.GetSlowDownMultiplier();
            FinishEffect(_iSettingsProvider.GetDefaultEffectDuration(), iTrigger.TriggerType);
        }

        /// <summary>
        /// Сброс силы и типа актуального эффекта после задержки
        /// </summary>
        /// <param name="delay"></param>
        private async void FinishEffect(float delay, TriggerType triggerType)
        {
            delay *= 1000;
            await UniTask.Delay((int)delay);
            if (_iTriggerReaction.ActualTrigger == triggerType)     
                _iTriggerReaction.ActualTrigger = TriggerType.None;
            if(_iGameplayState.CurrentGameState.Value == GameplayState.Gameplay)
                _iLevelMover.ResetMoveSpeed();
        }
    }
}