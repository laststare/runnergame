using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Utilities
{
    /// <summary>
    /// Родительский класс MonoBehaviour классов
    /// со списком для подписи/отмены подписи реактивных типов
    /// </summary>
    public class ViewBase : MonoBehaviour
    {
        protected readonly List<IDisposable> _disposables = new ();

        protected virtual void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}