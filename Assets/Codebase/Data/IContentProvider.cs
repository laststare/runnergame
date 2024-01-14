using Codebase.InterfaceAdapters.UI;
using Codebase.Views;
using Codebase.Views.UI;
using UnityEngine;

namespace Codebase.Data
{
    public interface IContentProvider
    {
        public Transform GetRunner();
        public float GetDefaultWorldSpeed();
        public float GetDefaultEffectDuration();
        public float GetSpeedUpMultiplier();
        public float GetSlowDownMultiplier();
        public float GetFlyHeight();
        public JumpButtonView GetJumpButtonView();
        public MainMenuView GetMainMenuView();
    }
}