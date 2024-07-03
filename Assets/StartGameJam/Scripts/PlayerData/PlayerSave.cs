using System;
using StartGameJam.Scripts.PlayerData.Audio;
using StartGameJam.Scripts.PlayerData.Fps;
using StartGameJam.Scripts.PlayerData.Localization;
using StartGameJam.Scripts.PlayerData.Score;
using StartGameJam.Scripts.PlayerData.Train;

namespace StartGameJam.Scripts.PlayerData
{
    [Serializable]
    public class PlayerSave
    {
        public LocalizationSettingsSave localizationSettingsSave;
        public VolumeSettingsSave volumeSettingsSave;
        public FpsSettingsSave fpsSettingsSave;
        public ScoreSettingsSave scoreSettingsSave;
        public TutorialSettingsSave tutorialSettingsSave;

        public PlayerSave()
        {
            localizationSettingsSave = new();
            volumeSettingsSave = new();
            fpsSettingsSave = new();
            tutorialSettingsSave = new();
            scoreSettingsSave = new();
        }
        
        public PlayerSave(PlayerData playerData)
        {
            localizationSettingsSave = new LocalizationSettingsSave(playerData.LocalizationSettings);
            volumeSettingsSave = new VolumeSettingsSave(playerData.VolumeSettings);
            fpsSettingsSave = new FpsSettingsSave(playerData.FpsSettings);
            scoreSettingsSave = new ScoreSettingsSave(playerData.ScoreSettings);
            tutorialSettingsSave = new TutorialSettingsSave(playerData.TutorialSettings);
        }
    }
}