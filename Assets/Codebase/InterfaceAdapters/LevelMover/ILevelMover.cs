using UniRx;

namespace Codebase.InterfaceAdapters.LevelMover
{
    public interface ILevelMover
    {
        ReactiveProperty<float> LevelMoveSpeed { get; set; }
        void ResetMoveSpeed();
        void StopMoving();
    }
}