using Codebase.Data;
using Codebase.InterfaceAdapters.GameState;
using Codebase.Utilities;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.UI.MainMenu
{
    /// <summary>
    /// Контроллер спавна основного меню игры
    /// Взаимодействие с ui элементом через ViewModel
    /// </summary>
    public class MainMenuSpawner : DisposableBase
    {
        public MainMenuSpawner(IContentProvider iContentProvider, Transform uiRoot, 
            IGameplayState iGameplayState, MainMenuViewModel mainMenuViewModel)
        {
            mainMenuViewModel.PlayButtonPressed.Subscribe(() =>
                iGameplayState.CurrentGameState.Value = GameplayState.Gameplay).AddTo(_disposables);
            mainMenuViewModel.RestartButtonPressed.Subscribe(() => 
                    iGameplayState.RestartGame.Notify()).AddTo(_disposables);

            iGameplayState.CurrentGameState.Subscribe(x =>
            {
                switch (x)
                {
                    case GameplayState.Gameplay:
                        mainMenuViewModel.HideAll.Notify();
                        break;
                    case GameplayState.FinishScreen:
                        mainMenuViewModel.ShowFinishScreen.Notify();
                        break;
                }
            }).AddTo(_disposables);
            
            var mainMenu = Object.Instantiate(iContentProvider.GetMainMenuView(), uiRoot);
            mainMenu.Init(mainMenuViewModel);
        }
       
    }
}