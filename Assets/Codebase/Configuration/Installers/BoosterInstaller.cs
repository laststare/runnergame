using Codebase.InterfaceAdapters.Boosters;
using Zenject;

namespace Codebase.Configuration.Installers
{
    public class BoosterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InjectSpeedEffectBooster();
        }
        
        private void InjectSpeedEffectBooster()
        {
            Container.BindInterfacesAndSelfTo<SpeedEffectBooster>()
                .AsSingle()
                .NonLazy();
        }
    }
}