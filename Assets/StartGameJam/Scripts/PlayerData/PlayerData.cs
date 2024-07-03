using System;
using StartGameJam.Scripts.PlayerData.Audio;
using StartGameJam.Scripts.PlayerData.Fps;
using StartGameJam.Scripts.PlayerData.Localization;
using StartGameJam.Scripts.PlayerData.Score;
using StartGameJam.Scripts.PlayerData.Train;
using UnityEditor;
using UnityEngine;

namespace StartGameJam.Scripts.PlayerData
{
    public class PlayerData
    {
        private static PlayerData _instance;
        public static PlayerData Instance => _instance ??= new PlayerData();

        public readonly LocalizationSettings LocalizationSettings = new();
        public readonly VolumeSettings VolumeSettings = new();
        public readonly FpsSettings FpsSettings = new();
        public readonly ScoreSettings ScoreSettings = new();
        public readonly TutorialSettings TutorialSettings = new();

#if !UNITY_EDITOR && UNITY_WEBGL
        private static readonly IPlayerDataSaveAndLoader SaveAndLoader = new WebSaveAndLoader();
#else
        private static readonly IPlayerDataSaveAndLoader SaveAndLoader = new DesktopSaveAndLoader();

#endif
        public event Action OnInit;

        private PlayerData()
        {
            Debug.Log("-||- PlayerGlobalData initializing");
            
            LoadData();
            SubsAfterFirstLoad();
        }
        
        public void ResetSaves() 
            => SaveAndLoader.ResetSave();
        
        private void LoadData()
        {
            var save = SaveAndLoader.Load();
            
            LocalizationSettings.LoadData(save.localizationSettingsSave);
            VolumeSettings.LoadData(save.volumeSettingsSave);
            FpsSettings.LoadData(save.fpsSettingsSave);
            ScoreSettings.LoadData(save.scoreSettingsSave);
            TutorialSettings.LoadData(save.tutorialSettingsSave);
        }
        
        private void SaveData() 
            => SaveAndLoader.Save(this);

        private void SubsAfterFirstLoad()
        {
            Debug.Log("-||- SubsAfterFirstLoad");
            
            ISettings[] settings =
            {
                LocalizationSettings,
                VolumeSettings, 
                FpsSettings,
                ScoreSettings,
                TutorialSettings
            };
            foreach (var setting in settings)
                setting.OnChange += SaveData;
            
            OnInit?.Invoke();
        }
        
#if UNITY_EDITOR
        [MenuItem("StartGameJam/Reset saves")]
#endif
        public static void ResetSave()
            => SaveAndLoader.ResetSave();
    }
}
