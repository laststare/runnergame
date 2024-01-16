using Codebase.Views.UI;
using UnityEngine;

namespace Codebase.Data
{
    /// <summary>
    /// Интерфейс для получения префабов на сцену
    /// </summary>
    public interface IContentProvider
    {
        public Transform GetRunner();
        public JumpButtonView GetJumpButtonView();
        public MainMenuView GetMainMenuView();
    }
}