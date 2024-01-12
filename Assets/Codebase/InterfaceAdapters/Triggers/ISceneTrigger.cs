using System;

namespace Codebase.InterfaceAdapters.Triggers
{
    public interface ISceneTrigger : ITrigger
    {
        TriggerType TriggerType { get;}
        event Action<ISceneTrigger> OnTriggerAction;
    }
}