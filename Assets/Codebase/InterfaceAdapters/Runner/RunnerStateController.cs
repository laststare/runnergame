using System;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerStateController : DisposableBase, IRunnerState
    {
        public bool IsGrounded { get; set; }
        private readonly IRunner _iRunner;
        private readonly Rigidbody _rigidbody;
        
        public RunnerStateController(IRunner iRunner)
        {
            _iRunner = iRunner;
            _rigidbody = _iRunner.RunnerTransform.GetComponent<Rigidbody>();
            VelocityController();
        }
        
        private async void VelocityController()
        {
            while (true)
            {
                if (IsAlive)
                {
                    IsGrounded = _rigidbody.velocity.y == 0;
                }
                await UniTask.Yield();
            }
        }
    }
}