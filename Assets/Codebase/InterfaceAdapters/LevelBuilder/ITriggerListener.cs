using Codebase.InterfaceAdapters.Triggers;
using External.Reactive;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public interface ITriggerListener
    {
        public ReactiveEvent<ISceneTrigger[]> triggersToSubscribe { get; set; }
        public ReactiveEvent<ISceneTrigger[]> triggersToUnSubscribe { get; set; }
    }
}