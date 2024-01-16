namespace Codebase.InterfaceAdapters.Runner
{
    /// <summary>
    /// Интерфейс получения состояний персонажа
    /// </summary>
    public interface IRunnerState
    {
        bool IsGrounded { get; }
    }
}
