using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public interface ILevelBuilder
    {
        Queue<Transform> PlatformsToMove { get; set; }
        ReactiveProperty<Transform> LastSpawnedPlatform { get; set; }
    }
}