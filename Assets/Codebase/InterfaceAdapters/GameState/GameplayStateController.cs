using Codebase.Utilities;
using External.Reactive;
using UniRx;

namespace Codebase.InterfaceAdapters.GameState
{
    /// <summary>
    /// Контроллер игрового состояния
    /// Отдаёт значения текущего игрового состояния
    /// и треггерит перезапуск игры
    /// </summary>
    public class GameplayStateController : DisposableBase, IGameplayState
    {
        public ReactiveProperty<GameplayState> CurrentGameState { get; } = new();
        public ReactiveTrigger RestartGame { get; } = new();

        public GameplayStateController()
        {
            RestartGame.Subscribe(() => CurrentGameState.Value = GameplayState.Gameplay).AddTo(_disposables);
        }

    }
}