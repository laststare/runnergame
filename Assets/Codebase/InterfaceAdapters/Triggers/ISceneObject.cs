using UnityEngine;

namespace Codebase.InterfaceAdapters.Triggers
{
    public interface ISceneObject
    {
        Transform GetTransform { get; }
    }
}