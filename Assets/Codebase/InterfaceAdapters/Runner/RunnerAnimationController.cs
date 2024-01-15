using Codebase.InterfaceAdapters.LevelMover;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Codebase.InterfaceAdapters.Runner
{
    public class RunnerAnimationController : DisposableBase
    {
        private readonly Animator _animator; 
        private readonly IRunnerState _iRunnerState;
        private float _levelMoveSpeed;
        private static readonly int Speed = Animator.StringToHash("Speed");

        public RunnerAnimationController(IRunner iRunner, IRunnerState iRunnerState, ILevelMover iLevelMover)
        {
            _animator = iRunner.RunnerTransform.GetChild(0).GetComponent<Animator>();
            iLevelMover.LevelMoveSpeed.Subscribe(UpdateMoveSpeed).AddTo(_disposables);
            _iRunnerState = iRunnerState;
            Run();
        }
        
        private void UpdateMoveSpeed(float speed)
        {
            _levelMoveSpeed = speed;
        }

        private async void Run()
        {
            while (true)
            {
                if (IsAlive)
                {
                    _animator.SetFloat(Speed, _levelMoveSpeed * 5);
                }
                await UniTask.Yield();
            }
        }

        private void JumpAnimation()
        {
            _animator.SetTrigger("Jump");
        }
    }
}