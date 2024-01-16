using Codebase.InterfaceAdapters.GameState;
using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.InterfaceAdapters.LevelMover;
using Codebase.InterfaceAdapters.TriggerListener;
using Zenject;

namespace Codebase.Configuration.Installers
{
    /// <summary>
    /// Базовый инсталлер, обеспечивающий работу игрового мира
    /// </summary>
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InjectGameStateController();
            InjectLevelBuilder();
            InjectLevelMover();
            InjectTriggerListener();
        }
        
        private void InjectGameStateController()
        {
            Container.BindInterfacesAndSelfTo<GameplayStateController>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InjectLevelBuilder()
        {
            Container.BindInterfacesAndSelfTo<LevelBuilderController>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InjectLevelMover()
        {
            Container.BindInterfacesAndSelfTo<LevelMoverController>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InjectTriggerListener()
        {
            Container.BindInterfacesAndSelfTo<TriggerListenerController>()
                .AsSingle()
                .NonLazy();
        }

    }
}
