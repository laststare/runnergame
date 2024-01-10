using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.InterfaceAdapters.LevelMover;
using Zenject;

namespace Codebase.Configuration.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InjectLevelBuilder();
            InjectLevelMover();
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
    }
}
