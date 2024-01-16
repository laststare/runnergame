using External.Reactive;

namespace Codebase.InterfaceAdapters.UI.MainMenu
{
    /// <summary>
    /// ViewModel основного меню
    /// Взаимодействие через реактивные типы 
    /// </summary>
    public class MainMenuViewModel
    {
        public readonly ReactiveTrigger PlayButtonPressed = new();
        public readonly ReactiveTrigger RestartButtonPressed = new();
        public readonly ReactiveTrigger HideAll = new();
        public readonly ReactiveTrigger ShowFinishScreen = new();
    }
}