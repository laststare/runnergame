using Codebase.Data;
using Codebase.Utilities;
using External.Reactive;
using UnityEngine;

namespace Codebase.InterfaceAdapters.UI
{
    public class JumpController : DisposableBase, IJimpButtonPressed
    {
        
        public ReactiveTrigger JumpButtonPressed { get; set; }

        private readonly IContentProvider _iContentProvider;
        private readonly JumpButtonViewModel _jumpButtonViewModel;
        private readonly Transform _uiRoot;
        
        public JumpController(IContentProvider iContentProvider, JumpButtonViewModel jumpButtonViewModel, Transform uiRoot)
        {
            JumpButtonPressed = new ReactiveTrigger();
            _iContentProvider = iContentProvider;
            _jumpButtonViewModel = jumpButtonViewModel;
            _uiRoot = uiRoot;
            SpawnJumpButton();
        }
        
        private void SpawnJumpButton()
        {
            var jumpButton = Object.Instantiate(_iContentProvider.GetJumpButtonView(), _uiRoot);
            jumpButton.Init(_jumpButtonViewModel, JumpButtonPressed);
        }

    }
}