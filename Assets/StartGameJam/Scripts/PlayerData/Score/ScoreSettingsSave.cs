using System;

namespace StartGameJam.Scripts.PlayerData.Score
{
    [Serializable]
    public class ScoreSettingsSave
    {
        public int ScoreRecord = 60;

        public ScoreSettingsSave()
        {
            ScoreRecord = 0;
        }
        
        public ScoreSettingsSave(ScoreSettings settings)
        {
            ScoreRecord = settings.ScoreRecord;
        }
    }
}