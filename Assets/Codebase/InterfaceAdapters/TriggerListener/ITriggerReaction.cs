using Codebase.InterfaceAdapters.Triggers;
using External.Reactive;

namespace Codebase.InterfaceAdapters.TriggerListener
{
    public interface ITriggerReaction
    {
        public ReactiveEvent<ISceneTrigger> TriggerReaction { get; set; }
        
        public TriggerType ActualTrigger { get; set; }
    }
}