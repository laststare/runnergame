﻿using System;
using Codebase.InterfaceAdapters.Triggers;
using UnityEngine;

namespace Codebase.Views
{
    /// <summary>
    /// Класс монеты (view)
    /// Имплементирует интерфейс ITrigger для обнаружения после загрузги сцены
    /// </summary>
    public class Coin : Trigger, ITrigger
    {
        [SerializeField] private TriggerType _triggerType;
        public TriggerType TriggerType => _triggerType;
        public event Action<ITrigger> OnTriggerAction;

        public Transform GetTransform => transform;
        
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            OnTriggerAction?.Invoke(this);
        }

    }
}