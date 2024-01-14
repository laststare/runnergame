using External.Reactive;

namespace Codebase.InterfaceAdapters.UI.JumpButton
{
    public class JumpButtonViewModel
    {
        public ReactiveEvent<bool> ShowJumpButton = new ReactiveEvent<bool>();
        public ReactiveTrigger JumpButtonPressed = new ReactiveTrigger();
    }
}