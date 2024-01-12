using System;
using Codebase.InterfaceAdapters.Triggers;
using UnityEngine;

namespace Codebase.Views
{
    public class SceneTriggerTrigger : Trigger, ISceneTrigger
    {
        [SerializeField] private TriggerType _triggerType;
        public TriggerType TriggerType => _triggerType;
        public event Action<ISceneTrigger> OnTriggerAction;

        public Transform GetTransform => transform;
        
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            OnTriggerAction?.Invoke(this);
        }

    }
}