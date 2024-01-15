namespace Codebase.Data
{
    public interface ISettingsProvider
    {
        public float GetDefaultWorldSpeed();
        public float GetDefaultEffectDuration();
        public float GetSpeedUpMultiplier();
        public float GetSlowDownMultiplier();
        public float GetFlyHeight();
    }
}