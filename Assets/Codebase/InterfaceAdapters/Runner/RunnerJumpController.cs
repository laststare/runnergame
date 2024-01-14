using Codebase.InterfaceAdapters.UI.JumpButton;
using Codebase.Utilities;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerJumpController : DisposableBase, IJumpAction
    {
        private readonly IRunnerState _irRunnerState;
        private readonly Rigidbody _rigidbody;

        public RunnerJumpController(IRunner iRunner, IRunnerState iRunnerState)
        {
            _irRunnerState = iRunnerState;
            _rigidbody = iRunner.RunnerTransform.GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            if (_irRunnerState.IsGrounded)
                _rigidbody.AddForce(Vector3.up * 11f, ForceMode.Impulse);
        }
    }
}