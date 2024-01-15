using Codebase.InterfaceAdapters.UI.JumpButton;
using Codebase.Utilities;
using External.Reactive;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerJumpController : DisposableBase, IJumpAction
    {
        public ReactiveTrigger Jump { get; set; } = new();
        private readonly IRunnerState _irRunnerState;
        private readonly Rigidbody _rigidbody;

        public RunnerJumpController(IRunner iRunner, IRunnerState iRunnerState)
        {
            _irRunnerState = iRunnerState;
            _rigidbody = iRunner.RunnerTransform.GetComponent<Rigidbody>();
            Jump.Subscribe(JumpPlayerUp).AddTo(_disposables);
        }

        private void JumpPlayerUp()
        {
            if (_irRunnerState.IsGrounded)
                _rigidbody.AddForce(Vector3.up * 11f, ForceMode.Impulse);
        }

    }
}