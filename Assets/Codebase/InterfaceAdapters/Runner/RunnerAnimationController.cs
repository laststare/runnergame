using Codebase.InterfaceAdapters.LevelMover;
using Codebase.InterfaceAdapters.UI.JumpButton;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerAnimationController : DisposableBase
    {
        private readonly Animator _animator; 
        private readonly Rigidbody _rigidbody;
        private readonly IRunnerState _iRunnerState;
        private readonly ILevelMover _iLevelMover;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int FreeFall = Animator.StringToHash("FreeFall");
        private static readonly int Grounded = Animator.StringToHash("Grounded");

        public RunnerAnimationController(IRunner iRunner, IRunnerState iRunnerState, ILevelMover iLevelMover, IJumpAction iJumpAction)
        {
            _animator = iRunner.RunnerTransform.GetChild(0).GetComponent<Animator>();
            _rigidbody = iRunner.RunnerTransform.GetComponent<Rigidbody>();
            _iLevelMover = iLevelMover;
            iJumpAction.Jump.Subscribe(JumpAnimation).AddTo(_disposables);
            _iRunnerState = iRunnerState;
            Run();
        }
        
        private async void Run()
        {
            while (IsAlive)
            {
                _animator.SetFloat(Speed, _iLevelMover.LevelMoveSpeed * 5);
                _animator.SetBool(Grounded, _iRunnerState.IsGrounded);
                _animator.SetBool(FreeFall, !_rigidbody.useGravity);
                await UniTask.Yield();
            }
        }
        
        private async void JumpAnimation()
        {
            _animator.SetTrigger(Jump);
            await UniTask.WaitForEndOfFrame();
            _animator.ResetTrigger(Jump);
        }
    }
}