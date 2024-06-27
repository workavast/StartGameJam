using System;
using StartGameJam.Scripts.PlayerData.Audio;
using StartGameJam.Scripts.PlayerData.Fps;
using StartGameJam.Scripts.PlayerData.Train;

namespace StartGameJam.Scripts.PlayerData
{
    [Serializable]
    public class PlayerSave
    {
        public VolumeSettingsSave volumeSettingsSave;
        public FpsSettingsSave fpsSettingsSave;
        public TutorialSettingsSave tutorialSettingsSave;

        public PlayerSave()
        {
            volumeSettingsSave = new();
            fpsSettingsSave = new();
            tutorialSettingsSave = new();
        }
        
        public PlayerSave(PlayerData playerData)
        {
            volumeSettingsSave = new VolumeSettingsSave(playerData.VolumeSettings);
            fpsSettingsSave = new FpsSettingsSave(playerData.FpsSettings);
            tutorialSettingsSave = new TutorialSettingsSave(playerData.TutorialSettings);
        }
        
        public PlayerSave(VolumeSettings volumeSettings, FpsSettings fpsSettings, TutorialSettings tutorialSettings)
        {
            volumeSettingsSave = new VolumeSettingsSave(volumeSettings);
            fpsSettingsSave = new FpsSettingsSave(fpsSettings);
            tutorialSettingsSave = new TutorialSettingsSave(tutorialSettings);
        }
    }
}