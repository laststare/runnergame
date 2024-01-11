using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.TriggerListener
{
    public class TriggerListenerController : DisposableBase
    {
        
        public TriggerListenerController(ITriggerListener triggerListener)
        {
            triggerListener.triggersToSubscribe.SubscribeWithSkip(SubsToTriggers).AddTo(_disposables);
            triggerListener.triggersToUnSubscribe.SubscribeWithSkip(UnSubsToTriggers).AddTo(_disposables);
        }
        
        private void SubsToTriggers(ISceneTrigger[] triggers)
        {
            foreach (var trigger in triggers) 
                trigger.OnTriggerAction += ListenToTrigger;
        }
        
        private void UnSubsToTriggers(ISceneTrigger[] triggers)
        {
            foreach (var trigger in triggers) 
                trigger.OnTriggerAction -= ListenToTrigger;
        }

        private void ListenToTrigger(TriggerType triggerType)
        {
            Debug.Log(triggerType.ToString());
        }
    }
}