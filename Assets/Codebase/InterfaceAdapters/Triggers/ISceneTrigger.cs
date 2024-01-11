using System;

namespace Codebase.InterfaceAdapters.Triggers
{
    public interface ISceneTrigger : ITrigger
    {
        event Action<TriggerType> OnTriggerAction;
    }
}