using UnityEngine;

namespace Codebase.InterfaceAdapters.Triggers
{
    /// <summary>
    /// Интерфейс получения трансформа объекта сцены
    /// </summary>
    public interface ISceneObject
    {
        Transform GetTransform { get; }
    }
}