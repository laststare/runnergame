using Codebase.Data;
using Codebase.InterfaceAdapters.GameState;
using Codebase.Utilities;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.UI.JumpButton
{
    /// <summary>
    /// Контроллер спавна кнопки прыжка
    /// Взаимодействие с ui элементом через ViewModel
    /// </summary>
    public class JumpButtonSpawner : DisposableBase
    {
        public JumpButtonSpawner(IContentProvider iContentProvider, JumpButtonViewModel jumpButtonViewModel, 
            Transform uiRoot, IJumpAction iJumpAction, IGameplayState iGameplayState)
        {
            iGameplayState.CurrentGameState.Subscribe(x =>
            {
                jumpButtonViewModel.ShowJumpButton.Notify(x == GameplayState.Gameplay);
            }).AddTo(_disposables);
            
            jumpButtonViewModel.JumpButtonPressed.Subscribe(() => iJumpAction.Jump.Notify()).AddTo(_disposables);
            
            var jumpButton = Object.Instantiate(iContentProvider.GetJumpButtonView(), uiRoot);
            jumpButton.Init(jumpButtonViewModel);
            jumpButton.gameObject.SetActive(false);
        }
        
    }
}