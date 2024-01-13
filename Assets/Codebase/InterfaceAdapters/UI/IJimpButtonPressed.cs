using External.Reactive;

namespace Codebase.InterfaceAdapters.UI
{
    public interface IJimpButtonPressed
    {
        ReactiveTrigger JumpButtonPressed { get; set; }
    }
}