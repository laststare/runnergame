using External.Reactive;

namespace Codebase.InterfaceAdapters.UI.JumpButton
{
    public class JumpButtonViewModel
    {
        public readonly ReactiveEvent<bool> ShowJumpButton = new ();
        public readonly ReactiveTrigger JumpButtonPressed = new ();
    }
}