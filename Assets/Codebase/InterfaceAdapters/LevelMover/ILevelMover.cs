namespace Codebase.InterfaceAdapters.LevelMover
{
    public interface ILevelMover
    {
        float LevelMoveSpeed { get; set; }
        void ResetMoveSpeed();
        void StopMoving();
    }
}