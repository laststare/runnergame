using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using External.Reactive;
using UniRx;

namespace Codebase.InterfaceAdapters.TriggerListener
{
    /// <summary>
    /// Контроллер реализации подписки/отписки с триггерами на сцене
    /// </summary>
    public class TriggerListenerController : DisposableBase, ITriggerReaction
    {
        public ReactiveEvent<ITrigger> TriggerReaction { get; } = new();
        public TriggerType ActualTrigger { get; set; }

        public TriggerListenerController(ITriggerListener triggerListener)
        {
            ActualTrigger = TriggerType.None;
            triggerListener.triggersToSubscribe.SubscribeWithSkip(SubsToTriggers).AddTo(_disposables);
            triggerListener.triggersToUnSubscribe.SubscribeWithSkip(UnSubsToTriggers).AddTo(_disposables);
        }
        
        private void SubsToTriggers(ITrigger[] triggers)
        {
            foreach (var trigger in triggers) 
                trigger.OnTriggerAction += ListenToTrigger;
        }
        
        private void UnSubsToTriggers(ITrigger[] triggers)
        {
            foreach (var trigger in triggers) 
                trigger.OnTriggerAction -= ListenToTrigger;
        }

        private void ListenToTrigger(ITrigger iTrigger) => TriggerReaction.Notify(iTrigger);
    }
}