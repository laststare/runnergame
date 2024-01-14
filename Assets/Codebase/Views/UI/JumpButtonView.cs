using Codebase.InterfaceAdapters.UI.JumpButton;
using Codebase.Utilities;
using UniRx;
using UnityEngine.UI;

namespace Codebase.Views.UI
{
    public class JumpButtonView : ViewBase
    {
        public void Init(JumpButtonViewModel viewModel)
        {
            GetComponent<Button>().onClick.AddListener(viewModel.JumpButtonPressed.Notify);
            viewModel.ShowJumpButton.Subscribe(x => gameObject.SetActive(x)).AddTo(_disposables);
        }
    }
}