using System;
using Codebase.InterfaceAdapters.Triggers;
using UnityEngine;

namespace Codebase.Views
{
    public class Obstacle : Trigger, ITrigger
    {
        [SerializeField] private TriggerType triggerType;
        public TriggerType TriggerType => triggerType;
        public event Action<ITrigger> OnTriggerAction;
        public Transform GetTransform => transform;
        
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            OnTriggerAction?.Invoke(this);
        }
    }
}