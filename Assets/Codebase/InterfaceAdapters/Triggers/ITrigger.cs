using UnityEngine;

namespace Codebase.InterfaceAdapters.Triggers
{
    public interface ITrigger
    {
        Transform GetTransform { get; }
    }
}