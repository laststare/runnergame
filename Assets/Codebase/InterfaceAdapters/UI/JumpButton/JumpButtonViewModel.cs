using External.Reactive;

namespace Codebase.InterfaceAdapters.UI.JumpButton
{
    /// <summary>
    /// ViewModel ui кнопки прыжка
    /// Взаимодействие через реактивные типы 
    /// </summary>
    public class JumpButtonViewModel
    {
        public readonly ReactiveEvent<bool> ShowJumpButton = new ();
        public readonly ReactiveTrigger JumpButtonPressed = new ();
    }
}