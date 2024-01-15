using Codebase.Data;
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
        private readonly IRunnerState _iRunnerState;
        private readonly Rigidbody _rigidbody;
        private readonly float _jumpStrength;

        public RunnerJumpController(IRunner iRunner, IRunnerState iRunnerState, ISettingsProvider iSettingsProvider)
        {
            _iRunnerState = iRunnerState;
            _jumpStrength = iSettingsProvider.GetJumpStrength();
            _rigidbody = iRunner.RunnerTransform.GetComponent<Rigidbody>();
            Jump.Subscribe(JumpPlayerUp).AddTo(_disposables);
        }

        private void JumpPlayerUp()
        {
            if (!_iRunnerState.IsGrounded)return; 
            _rigidbody.AddForce(Vector3.up * _jumpStrength, ForceMode.VelocityChange);
        }

    }
}