using Codebase.Utilities;
using UnityEngine;

namespace Codebase.Views
{
    /// <summary>
    /// Базовый класс для триггеров на сцене
    /// </summary>
    public abstract class Trigger : ViewBase
    {
        protected virtual void OnTriggerEnter(Collider other)
        {
            
        }
    }
}