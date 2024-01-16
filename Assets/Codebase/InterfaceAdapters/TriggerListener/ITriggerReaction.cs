using Codebase.InterfaceAdapters.Triggers;
using External.Reactive;

namespace Codebase.InterfaceAdapters.TriggerListener
{
    /// <summary>
    /// Интерфейс получения информации о взаимодействии персонажа с триггером на сцене
    /// </summary>
    public interface ITriggerReaction
    {
        public ReactiveEvent<ITrigger> TriggerReaction { get; }
        
        public TriggerType ActualTrigger { get; set; }
    }
}