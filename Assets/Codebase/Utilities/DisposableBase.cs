using System;
using System.Collections.Generic;

namespace Codebase.Utilities
{
    /// <summary>
    /// Родительский класс для Disposable классов (не MonoBehaviour)
    /// со списком для подписи/отмены подписи реактивных типов
    /// </summary>
    public class DisposableBase : IDisposable
    {
        protected bool IsAlive = true;
        protected readonly List<IDisposable> _disposables = new List<IDisposable>();
        
        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }

            OnDispose();
        }
        
        protected virtual void OnDispose()
        {
            IsAlive = false;
        }
    }
}