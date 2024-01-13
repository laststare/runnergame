using Codebase.InterfaceAdapters.UI;
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
            
            Container.BindInterfacesAndSelfTo<JumpController>()
                .AsSingle()
                .NonLazy();
        }
    }
}