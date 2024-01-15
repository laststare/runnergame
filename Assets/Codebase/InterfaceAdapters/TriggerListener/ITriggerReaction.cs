using Codebase.InterfaceAdapters.Triggers;
using External.Reactive;

namespace Codebase.InterfaceAdapters.TriggerListener
{
    public interface ITriggerReaction
    {
        public ReactiveEvent<ITrigger> TriggerReaction { get; }
        
        public TriggerType ActualTrigger { get; set; }
    }
}