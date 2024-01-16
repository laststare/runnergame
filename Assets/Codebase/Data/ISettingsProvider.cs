namespace Codebase.Data
{
    /// <summary>
    /// Интерфейс для получения настроек игрового мира
    /// </summary>
    public interface ISettingsProvider
    {
        public float GetDefaultWorldSpeed();
        public float GetDefaultEffectDuration();
        public float GetSpeedUpMultiplier();
        public float GetSlowDownMultiplier();
        public float GetFlyHeight();
        public float GetJumpStrength();
    }
}