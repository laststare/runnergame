using Codebase.Data;
using UnityEngine;
using Zenject;

namespace Codebase.Configuration.Installers
{
    /// <summary>
    /// Инсталлер для провайдера настроек игрового мира
    /// </summary>
    [CreateAssetMenu(fileName = "SettingsProviderInstaller", menuName = "Installers/SettingsProviderInstaller")]
    public class SettingsProviderInstaller : ScriptableObjectInstaller<ContentProviderInstaller>
    {
        public SettingsProvider SettingsProvider;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ISettingsProvider>().FromInstance(SettingsProvider).AsSingle();
        }
    }
}