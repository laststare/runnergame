
namespace Codebase.InterfaceAdapters.LevelMover
{
    /// <summary>
    /// Интерфейс управления скоростью движения платформ на уровне
    /// </summary>
    public interface ILevelMover
    {
        float LevelMoveSpeed { get; set; }
        void ResetMoveSpeed();
        void StopMoving();
    }
}