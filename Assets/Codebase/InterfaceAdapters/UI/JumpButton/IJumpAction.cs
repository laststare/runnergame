using External.Reactive;

namespace Codebase.InterfaceAdapters.UI.JumpButton
{
    /// <summary>
    /// Интерфейс получения действия прыжка
    /// </summary>
    public interface IJumpAction
    {
        ReactiveTrigger Jump { get; }
    }
}