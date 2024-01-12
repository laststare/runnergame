using Codebase.InterfaceAdapters.Boosters;
using Zenject;

namespace Codebase.Configuration.Installers
{
    public class EffectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InjectSpeedEffectBooster();
            InjectFlyEffectBooster();
            InjectObstacleEffect();
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
        
        private void InjectObstacleEffect()
        {
            Container.BindInterfacesAndSelfTo<ObstacleEffect>()
                .AsSingle()
                .NonLazy();
        }
    }
}