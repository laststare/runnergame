using Codebase.InterfaceAdapters.Triggers;
using External.Reactive;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    /// <summary>
    /// Интерфейс для получения триггеров сцены для реализации и отмены подписи
    /// </summary>
    public interface ITriggerListener
    {
        public ReactiveEvent<ITrigger[]> triggersToSubscribe { get; }
        public ReactiveEvent<ITrigger[]> triggersToUnSubscribe { get; }
    }
}