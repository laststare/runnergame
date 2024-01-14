using Codebase.InterfaceAdapters.UI.JumpButton;
using Codebase.InterfaceAdapters.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace Codebase.Configuration.Installers
{
    public class UInstaller : MonoInstaller
    {
        [SerializeField] private Transform uiRoot;
        public override void InstallBindings()
        {
            InjectRoot();
            InjectJumpController();
            InjectMainMenuSpawner();
        }

        private void InjectRoot()
        {
            Container.Bind<Transform>()
                .FromInstance(uiRoot)
                .AsSingle();
        }

        private void InjectJumpController()
        {
            Container.Bind<JumpButtonViewModel>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<JumpButtonSpawner>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InjectMainMenuSpawner()
        {
            Container.Bind<MainMenuViewModel>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<MainMenuSpawner>()
                .AsSingle()
                .NonLazy();
        }
    }
}