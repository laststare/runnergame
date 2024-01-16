using External.Reactive;
using UniRx;

namespace Codebase.InterfaceAdapters.GameState
{
    /// <summary>
    /// Интерфейс получения игрового состояния и перезапуска игры
    /// </summary>
    public interface IGameplayState
    {
        ReactiveProperty<GameplayState> CurrentGameState { get; }
        ReactiveTrigger RestartGame { get; }
    }
}