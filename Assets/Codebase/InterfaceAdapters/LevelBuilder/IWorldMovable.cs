using System.Collections.Generic;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelBuilder
{
    public interface IWorldMovable
    {
        List<Transform> ObjectsToMove { get; set; }
    }
}