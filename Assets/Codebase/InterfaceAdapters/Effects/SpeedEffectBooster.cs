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
    public class SpeedEffectBooster :  DisposableBase
    {
        private readonly ILevelMover _iLevelMover;
        private readonly IContentProvider _iContentProvider;
        private readonly ITriggerReaction _iTriggerReaction;
        private readonly IGameplayState _iGameplayState;
        
        public SpeedEffectBooster(ITriggerReaction iTriggerReaction, ILevelMover iLevelMover, IContentProvider iContentProvider, IGameplayState iGameplayState)
        {
            _iLevelMover = iLevelMover;
            _iContentProvider = iContentProvider;
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

        private void SpeedUpEffect(ISceneTrigger iSceneTrigger)
        {
            iSceneTrigger.GetTransform.gameObject.SetActive(false);
            if (_iTriggerReaction.ActualTrigger == iSceneTrigger.TriggerType)
                return;
            _iTriggerReaction.ActualTrigger = iSceneTrigger.TriggerType;
            _iLevelMover.LevelMoveSpeed *= _iContentProvider.GetSpeedUpMultiplier();
            FinishEffect(_iContentProvider.GetDefaultEffectDuration());
        }

        private void SlowDownEffect(ISceneTrigger iSceneTrigger)
        {
            iSceneTrigger.GetTransform.gameObject.SetActive(false);
            if (_iTriggerReaction.ActualTrigger == iSceneTrigger.TriggerType)
                return;
            _iTriggerReaction.ActualTrigger = iSceneTrigger.TriggerType;
            _iLevelMover.LevelMoveSpeed /= _iContentProvider.GetSlowDownMultiplier();
            FinishEffect(_iContentProvider.GetDefaultEffectDuration());
        }

        private async void FinishEffect(float delay)
        {
            delay *= 1000;
            await UniTask.Delay((int)delay);
            _iTriggerReaction.ActualTrigger = TriggerType.None;
            if(_iGameplayState.CurrentGameState.Value == GameplayState.Gameplay)
                _iLevelMover.ResetMoveSpeed();
        }
    }
}