using Codebase.InterfaceAdapters.UI.MainMenu;
using Codebase.Utilities;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Views.UI
{
    public class MainMenuView : ViewBase
    {
        [SerializeField] private Button playButton, restartButton;
        [SerializeField] private GameObject title;
        public void Init(MainMenuViewModel mainMenuViewModel)
        {
            playButton.onClick.AddListener(() =>
            {
                mainMenuViewModel.PlayButtonPressed.Notify();
            });
            
            restartButton.onClick.AddListener(() =>
            {
                mainMenuViewModel.RestartButtonPressed.Notify();
            });
            
            mainMenuViewModel.HideAll.Subscribe(() =>
            {
                playButton.gameObject.SetActive(false);
                restartButton.gameObject.SetActive(false);
                title.SetActive(false);
            }).AddTo(_disposables);
            
            mainMenuViewModel.ShowFinishScreen.Subscribe(() =>
            {
                restartButton.gameObject.SetActive(true);
                title.SetActive(true);
            }).AddTo(_disposables);
        }
    }
}