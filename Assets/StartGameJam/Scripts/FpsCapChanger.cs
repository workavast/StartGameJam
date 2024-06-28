using StartGameJam.Scripts.PlayerData.Fps;
using UnityEngine;

namespace StartGameJam.Scripts
{
    public class FpsCapChanger
    {
        private readonly FpsSettings _fpsSettings;

        public int FpsCap => _fpsSettings.FpsCap;
        
        public FpsCapChanger(FpsSettings fpsSettings)
        {
            _fpsSettings = fpsSettings;
            ApplyFpsCap(_fpsSettings.FpsCap);
        }

        public void SetFpsCap(int newFpsCap)
        {
            ApplyFpsCap(newFpsCap);
            _fpsSettings.SetFpsCap(newFpsCap);
        }
        
        private static void ApplyFpsCap(int fpsCap) 
            => Application.targetFrameRate = fpsCap;
    }
}