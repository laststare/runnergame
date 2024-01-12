using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using External.Reactive;
using UniRx;

namespace Codebase.InterfaceAdapters.TriggerListener
{
    public class TriggerListenerController : DisposableBase, ITriggerReaction
    {
        public ReactiveEvent<ISceneTrigger> TriggerReaction { get; set; }
        public TriggerType ActualTrigger { get; set; }

        public TriggerListenerController(ITriggerListener triggerListener)
        {
            TriggerReaction = new ReactiveEvent<ISceneTrigger>();
            ActualTrigger = TriggerType.None;
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

        private void ListenToTrigger(ISceneTrigger iSceneTrigger) => TriggerReaction.Notify(iSceneTrigger);
    }
}