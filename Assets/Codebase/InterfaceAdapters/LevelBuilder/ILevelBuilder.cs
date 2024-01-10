using External.Reactive;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public interface ILevelBuilder
    {
        ReactiveProperty<Transform> LastSpawnedPlatform { get; set; }
        ReactiveTrigger DeletePlatform { get; set; }
    }
}