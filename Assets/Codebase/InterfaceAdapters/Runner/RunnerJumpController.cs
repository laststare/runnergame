using Codebase.InterfaceAdapters.UI;
using Codebase.Utilities;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerJumpController : DisposableBase
    {
        private readonly IRunner _iRunner;
        private readonly IRunnerState _irRunnerState;
        private readonly Rigidbody _rigidbody;
        
        public RunnerJumpController(IRunner iRunner, IRunnerState iRunnerState, IJimpButtonPressed iJimpButtonPressed)
        {
            _iRunner = iRunner;
            _irRunnerState = iRunnerState;
            _rigidbody = _iRunner.RunnerTransform.GetComponent<Rigidbody>();
            iJimpButtonPressed.JumpButtonPressed.Subscribe(Jump).AddTo(_disposables);
            
            // Observable.EveryUpdate() // поток update
            //     .Where(_ => Input.GetKeyDown(KeyCode.Space)) // фильтруем на нажатие любой клавиши
            //     .Subscribe (x => { // подписываемся
            //         Jump(); // вызываем метод OnKeyDown c параметром нажатой клавиши
            //     }).AddTo(_disposables); 
        }

        private void Jump()
        {
            if(_irRunnerState.IsGrounded)
                _rigidbody.AddForce(Vector3.up * 11f, ForceMode.Impulse);
        }
    }
}