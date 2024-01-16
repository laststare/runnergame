using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    /// <summary>
    /// Интерфейс загрузчика сцен
    /// Отдаёт очередь платформ и последнюю полученную платформу
    /// </summary>
    public interface ILevelBuilder
    {
        Queue<Transform> PlatformsToMove { get; }
        ReactiveProperty<Transform> LastSpawnedPlatform { get; }
    }
}