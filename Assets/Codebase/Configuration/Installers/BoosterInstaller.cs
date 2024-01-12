using Codebase.InterfaceAdapters.Boosters;
using Zenject;

namespace Codebase.Configuration.Installers
{
    public class BoosterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InjectSpeedEffectBooster();
            InjectFlyEffectBooster();
        }
        
        private void InjectSpeedEffectBooster()
        {
            Container.BindInterfacesAndSelfTo<SpeedEffectBooster>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InjectFlyEffectBooster()
        {
            Container.BindInterfacesAndSelfTo<FlyEffectBooster>()
                .AsSingle()
                .NonLazy();
        }
    }
}