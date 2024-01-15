using Codebase.InterfaceAdapters.GameState;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerStateController : DisposableBase, IRunnerState
    {
        public bool IsGrounded { get; set; }
        private readonly Rigidbody _rigidbody;
        public RunnerStateController(IRunner iRunner, IGameplayState iGameplayState)
        {
            _rigidbody = iRunner.RunnerTransform.GetComponent<Rigidbody>();
            var startPosition = iRunner.RunnerTransform.position;
            iGameplayState.RestartGame.Subscribe(() =>
                iRunner.RunnerTransform.position = startPosition).AddTo(_disposables);
     
            VelocityController();
        }
        
        private async void VelocityController()
        {
            while (IsAlive)
            {
                IsGrounded = _rigidbody.velocity.y == 0 && _rigidbody.useGravity;
                await UniTask.Yield();
            }
        }
    }
}