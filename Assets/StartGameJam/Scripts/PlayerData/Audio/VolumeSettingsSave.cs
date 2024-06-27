using System;

namespace StartGameJam.Scripts.PlayerData.Audio
{
    [Serializable]
    public sealed class VolumeSettingsSave
    {
        public float MasterVolume = 1f;
        public float MusicVolume = 0.5f;
        public float EffectsVolume = 0.5f;

        public VolumeSettingsSave()
        {
            MasterVolume = 1;
            MusicVolume = 0.5f;
            EffectsVolume = 0.5f;
        }
        
        public VolumeSettingsSave(VolumeSettings settings)
        {
            MasterVolume = settings.Master;
            MusicVolume = settings.MusicVolume;
            EffectsVolume = settings.EffectsVolume;
        }
    }
}