using External.Reactive;
using UniRx;

namespace Codebase.InterfaceAdapters.GameState
{
    public interface IGameplayState
    {
        ReactiveProperty<GameplayState> CurrentGameState { get; }
        ReactiveTrigger RestartGame { get; }
    }
}