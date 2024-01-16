using System;
using Codebase.InterfaceAdapters.Triggers;
using UnityEngine;

namespace Codebase.Views
{
    /// <summary>
    /// Класс препятствия (view)
    /// Имплементирует интерфейс ITrigger для обнаружения после загрузги сцены
    /// </summary>
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