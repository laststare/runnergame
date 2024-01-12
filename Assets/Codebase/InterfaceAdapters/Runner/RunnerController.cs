using Codebase.Data;
using Codebase.Utilities;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerController : DisposableBase, IRunner
    {
        private readonly IContentProvider _iContentProvider;
        private Transform _runner;
        public Transform RunnerTransform => _runner;
        
        public RunnerController(IContentProvider iContentProvider)
        {
            _iContentProvider = iContentProvider;
            SpawnRunner();
        }
        
        private void SpawnRunner()
        {
           _runner = Object.Instantiate(_iContentProvider.GetRunner(), Vector3.zero, Quaternion.identity);
        }

       
    }
}