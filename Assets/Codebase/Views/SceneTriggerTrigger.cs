using System;
using Codebase.InterfaceAdapters.Triggers;
using UnityEngine;

namespace Codebase.Views
{
    public class SceneTriggerTrigger : Trigger, ISceneTrigger
    {
        [SerializeField] private TriggerType triggerType;

        public event Action<TriggerType> OnTriggerAction;
        public Transform GetTransform => transform;
        
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            OnTriggerAction?.Invoke(triggerType);
        }

    }
}