using Codebase.InterfaceAdapters.UI;
using Codebase.Views;
using Codebase.Views.UI;
using UnityEngine;

namespace Codebase.Data
{
    public interface IContentProvider
    {
        public Transform GetRunner();
        public JumpButtonView GetJumpButtonView();
        public MainMenuView GetMainMenuView();
    }
}