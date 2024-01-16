using Codebase.InterfaceAdapters.Effects;
using Zenject;

namespace Codebase.Configuration.Installers
{
    /// <summary>
    /// Инсталлер для эффетков, влияющих на персонажа или игровой мир
    /// Каждый контроллер самостоятельно реализует эффект, взаимодействуя с другими классами через их интерфейсы
    /// Реализация текущих эффектов (и создание новых) не приводят к переписыванию классов персонажа или классов работы мира
    /// </summary>
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