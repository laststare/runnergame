using System;

namespace Codebase.InterfaceAdapters.Triggers
{
    public interface ITrigger : ISceneObject
    {
        TriggerType TriggerType { get;}
        event Action<ITrigger> OnTriggerAction;
    }
}