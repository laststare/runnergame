using Codebase.InterfaceAdapters.GameState;
using Codebase.InterfaceAdapters.LevelMover;
using Codebase.InterfaceAdapters.TriggerListener;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using UniRx;

namespace Codebase.InterfaceAdapters.Effects
{
    public class ObstacleEffect : DisposableBase
    {
        private readonly ILevelMover _iLevelMover;
        private readonly ITriggerReaction _iTriggerReaction;
        private readonly IGameplayState _iGameplayState;
        
        public ObstacleEffect (ITriggerReaction iTriggerReaction, ILevelMover iLevelMover, IGameplayState iGameplayState)
        {
            _iLevelMover = iLevelMover;
            _iTriggerReaction = iTriggerReaction;
            _iGameplayState = iGameplayState;
            
            iTriggerReaction.TriggerReaction.SubscribeWithSkip(x =>
            {
                if (x.TriggerType == TriggerType.Obstacle)
                    Obstacle(x);
            }).AddTo(_disposables);
        }

        private void Obstacle(ITrigger iTrigger)
        {
            _iTriggerReaction.ActualTrigger = iTrigger.TriggerType;
            _iLevelMover.StopMoving();
            _iGameplayState.CurrentGameState.Value = GameplayState.FinishScreen;
        }
    }
}