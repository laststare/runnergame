using Codebase.InterfaceAdapters.Triggers;
using External.Reactive;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public interface ITriggerListener
    {
        public ReactiveEvent<ITrigger[]> triggersToSubscribe { get; }
        public ReactiveEvent<ITrigger[]> triggersToUnSubscribe { get; }
    }
}