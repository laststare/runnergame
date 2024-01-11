using External.Reactive;

namespace Codebase.InterfaceAdapters.TriggerListener
{
    public interface ITriggerReaction
    {
        public ReactiveEvent<TriggerType> TriggerReaction { get; set; }
        
        public TriggerType ActualTrigger { get; set; }
    }
}