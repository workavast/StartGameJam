﻿using System;

namespace StartGameJam.Scripts.PlayerData.Fps
{
    public class FpsSettings : ISettings
    {
        public int FpsCap { get; private set; }
        
        public event Action OnChange;

        public FpsSettings()
        {
            FpsCap = 60;
        }

        public void SetFpsCap(int newFpsCap)
        {
            FpsCap = newFpsCap;
            OnChange?.Invoke();
        }
        
        public void LoadData(FpsSettingsSave save)
        {
            FpsCap = save.FpsCap;
        }
    }
}