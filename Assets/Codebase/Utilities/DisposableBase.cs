using System;
using System.Collections.Generic;

namespace Codebase.Utilities
{
    public class DisposableBase : IDisposable
    {
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
            
        }
    }
}