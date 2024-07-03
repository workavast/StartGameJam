﻿using System;

namespace StartGameJam.Scripts.PlayerData.Localization
{
    [Serializable]
    public sealed class LocalizationSettingsSave
    {
        public bool Initializaed = false;
        public int LocalizationId = 1;
        
        public LocalizationSettingsSave()
        {
            Initializaed = false;
            LocalizationId = 1;
        }
        
        public LocalizationSettingsSave(LocalizationSettings settings)
        {
            Initializaed = settings.Initializaed;
            LocalizationId = settings.LocalizationId;
        }
    }
}