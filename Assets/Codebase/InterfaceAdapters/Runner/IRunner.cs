using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    /// <summary>
    /// Интерфейс получения трансформа персонажа
    /// </summary>
    public interface IRunner
    {
        Transform RunnerTransform { get; }
    }
}