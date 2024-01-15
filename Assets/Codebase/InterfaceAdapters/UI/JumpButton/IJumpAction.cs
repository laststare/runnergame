using External.Reactive;

namespace Codebase.InterfaceAdapters.UI.JumpButton
{
    public interface IJumpAction
    {
        ReactiveTrigger Jump { get; set; }
    }
}