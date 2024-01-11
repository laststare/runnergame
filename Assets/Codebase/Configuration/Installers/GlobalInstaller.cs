using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.InterfaceAdapters.LevelMover;
using Codebase.InterfaceAdapters.TriggerListener;
using Zenject;

namespace Codebase.Configuration.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InjectLevelBuilder();
            InjectLevelMover();
            InjectTriggerListener();
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
