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
        private readonly IRunner _iRunner;
        private readonly Rigidbody _rigidbody;
        private Vector3 _startPosition;
        
        public RunnerStateController(IRunner iRunner, IGameplayState iGameplayState)
        {
            _iRunner = iRunner;
            _rigidbody = _iRunner.RunnerTransform.GetComponent<Rigidbody>();
            _startPosition = _iRunner.RunnerTransform.position;
            iGameplayState.RestartGame.Subscribe(() =>
                iRunner.RunnerTransform.position = _startPosition).AddTo(_disposables);
     
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