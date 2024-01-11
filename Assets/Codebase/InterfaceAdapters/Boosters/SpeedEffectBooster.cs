﻿using Codebase.Data;
using Codebase.InterfaceAdapters.LevelMover;
using Codebase.InterfaceAdapters.TriggerListener;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Codebase.InterfaceAdapters.Boosters
{
    public class SpeedEffectBooster :  DisposableBase
    {
        private readonly ILevelMover _iLevelMover;
        private readonly IContentProvider _iContentProvider;
        private readonly ITriggerReaction _iTriggerReaction;
        
        public SpeedEffectBooster(ITriggerReaction iTriggerReaction, ILevelMover iLevelMover, IContentProvider iContentProvider)
        {
            _iLevelMover = iLevelMover;
            _iContentProvider = iContentProvider;
            _iTriggerReaction = iTriggerReaction;
            
            iTriggerReaction.TriggerReaction.SubscribeWithSkip(x =>
            {
                if (x == TriggerType.SpeedUpCoin)
                    SpeedUpEffect(x);
            }).AddTo(_disposables);
            
            iTriggerReaction.TriggerReaction.SubscribeWithSkip(x =>
            {
                if (x == TriggerType.SlowDownCoin)
                    SlowDownEffect(x);
            }).AddTo(_disposables);
        }

        private void SpeedUpEffect(TriggerType triggerType)
        {
            if (_iTriggerReaction.ActualTrigger == triggerType)
                return;
            _iTriggerReaction.ActualTrigger = triggerType;
            _iLevelMover.LevelMoveSpeed *= _iContentProvider.GetSpeedUpMultiplier();
            FinishEffect(_iContentProvider.GetDefaultEffectDuration());
        }

        private void SlowDownEffect(TriggerType triggerType)
        {
            if (_iTriggerReaction.ActualTrigger == triggerType)
                return;
            _iTriggerReaction.ActualTrigger = triggerType;
            _iLevelMover.LevelMoveSpeed /= _iContentProvider.GetSlowDownMultiplier();
            FinishEffect(_iContentProvider.GetDefaultEffectDuration());
        }

        private async void FinishEffect(float delay)
        {
            delay *= 1000;
            await UniTask.Delay((int)delay);
            _iLevelMover.ResetMoveSpeed();
        }
    }
}