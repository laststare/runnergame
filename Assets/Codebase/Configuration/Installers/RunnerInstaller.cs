using Codebase.InterfaceAdapters.Runner;
using Zenject;

namespace Codebase.Configuration.Installers
{
    /// <summary>
    /// Инсталлер персонажа, отвечает за спав, анимации и реакцию на пользовательский ввод
    /// Функционал поделён на контроллеры, что бы декомпозировать интерактивность персонажа, соблюдая SRP
    /// Новые возможности персонажа можно добавлять новыми контроллерами, не изменяя текущие
    /// </summary>
    public class RunnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InjectRunner();
            InjectRunnerJumpController();
            InjectRunnerStateController();
            InjectRunnerAnimationController();
        }
        
        private void InjectRunner()
        {
            Container.BindInterfacesAndSelfTo<RunnerSpawner>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InjectRunnerJumpController()
        {
            Container.BindInterfacesAndSelfTo<RunnerJumpController>()
                .AsSingle()
                .NonLazy();
        }

        private void InjectRunnerStateController()
        {
            Container.BindInterfacesAndSelfTo<RunnerStateController>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InjectRunnerAnimationController()
        {
            Container.BindInterfacesAndSelfTo<RunnerAnimationController>()
                .AsSingle()
                .NonLazy();
        }
    }
}