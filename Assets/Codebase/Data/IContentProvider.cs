using UnityEngine;

namespace Codebase.Data
{
    public interface IContentProvider
    {
        public Transform GetRunner();
        public float GetDefaultWorldSpeed();
        public float GetDefaultEffectDuration();
        public float GetSpeedUpMultiplier();
        public float GetSlowDownMultiplier();
    }
}