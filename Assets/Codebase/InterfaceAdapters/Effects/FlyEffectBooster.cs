using Codebase.Data;
using Codebase.InterfaceAdapters.Runner;
using Codebase.InterfaceAdapters.TriggerListener;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Effects
{
    public class FlyEffectBooster :  DisposableBase
    {
        private readonly IRunner _iRunner;
        private readonly IContentProvider _iContentProvider;
        private readonly ITriggerReaction _iTriggerReaction;
        private readonly Rigidbody _rigidbody;

        public FlyEffectBooster(ITriggerReaction iTriggerReaction, IRunner iRunner, IContentProvider iContentProvider)
        {
            _iRunner = iRunner;
            _iContentProvider = iContentProvider;
            _iTriggerReaction= iTriggerReaction;
            _rigidbody = _iRunner.RunnerTransform.GetComponent<Rigidbody>();
            iTriggerReaction.TriggerReaction.SubscribeWithSkip(x =>
            {
                if (x.TriggerType == TriggerType.FlyCoin)
                    FlyEffect(x);
            }).AddTo(_disposables);
        }

        private void FlyEffect(ISceneTrigger iSceneTrigger)
        {
            iSceneTrigger.GetTransform.gameObject.SetActive(false);
            if (_iTriggerReaction.ActualTrigger == iSceneTrigger.TriggerType)
                return;
            _iTriggerReaction.ActualTrigger = iSceneTrigger.TriggerType;
           
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            
            _iRunner.RunnerTransform.DOMoveY(_iContentProvider.GetFlyHeight(), 1f);
            FinishEffect(_iContentProvider.GetDefaultEffectDuration());
        }
        
        private async void FinishEffect(float delay)
        {
            delay *= 1000;
            await UniTask.Delay((int)delay);
            _iRunner.RunnerTransform.DOMoveY(0, 1f).OnComplete(() =>
            {
                _rigidbody.useGravity = true;
                _rigidbody.isKinematic = false;
            });
            _iTriggerReaction.ActualTrigger = TriggerType.None;
        }
    }
}