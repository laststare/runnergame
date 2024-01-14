using External.Reactive;

namespace Codebase.InterfaceAdapters.UI.MainMenu
{
    public class MainMenuViewModel
    {
        public ReactiveTrigger PlayButtonPressed = new();
        public ReactiveTrigger RestartButtonPressed = new();
        public ReactiveTrigger HideAll = new();
        public ReactiveTrigger ShowFinishScreen = new();
    }
}