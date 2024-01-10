﻿using Codebase.Data;
using UnityEngine;
using Zenject;

namespace Codebase.Configuration.Installers
{
    [CreateAssetMenu(fileName = "ContentProviderInstaller", menuName = "Installers/ContentProviderInstaller")]
    public class ContentProviderInstaller : ScriptableObjectInstaller<ContentProviderInstaller>
    {
        public ContentProvider contentProvider;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IContentProvider>().FromInstance(contentProvider).AsSingle();
        }
    }
}