using Codebase.InterfaceAdapters.UI;
using Codebase.Utilities;
using External.Reactive;
using UnityEngine.UI;

namespace Codebase.Views
{
    public class JumpButtonView : ViewBase
    {
        public void Init(JumpButtonViewModel viewModel, ReactiveTrigger jumpButtonPressed )
        {
            GetComponent<Button>().onClick.AddListener(jumpButtonPressed.Notify);
        }
    }
}