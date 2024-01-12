using Codebase.InterfaceAdapters.LevelMover;
using Codebase.InterfaceAdapters.TriggerListener;
using Codebase.InterfaceAdapters.Triggers;
using Codebase.Utilities;
using UniRx;

namespace Codebase.InterfaceAdapters.Boosters
{
    public class ObstacleEffect : DisposableBase
    {
        private readonly ILevelMover _iLevelMover;
        private readonly ITriggerReaction _iTriggerReaction;
        
        public ObstacleEffect (ITriggerReaction iTriggerReaction, ILevelMover iLevelMover)
        {
            _iLevelMover = iLevelMover;
            _iTriggerReaction = iTriggerReaction;
            
            iTriggerReaction.TriggerReaction.SubscribeWithSkip(x =>
            {
                if (x.TriggerType == TriggerType.Obstacle)
                    Obstacle(x);
            }).AddTo(_disposables);
        }

        private void Obstacle(ISceneTrigger iSceneTrigger)
        {
            _iTriggerReaction.ActualTrigger = iSceneTrigger.TriggerType;
            _iLevelMover.StopMoving();
        }
    }
}