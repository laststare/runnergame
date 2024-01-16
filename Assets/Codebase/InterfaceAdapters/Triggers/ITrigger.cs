using System;

namespace Codebase.InterfaceAdapters.Triggers
{
    /// <summary>
    /// Интерфейс получения объекта триггера и определения его типа
    /// </summary>
    public interface ITrigger : ISceneObject
    {
        TriggerType TriggerType { get;}
        event Action<ITrigger> OnTriggerAction;
    }
}