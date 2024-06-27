namespace StartGameJam.Scripts.PlayerData
{
    public interface IPlayerDataSaveAndLoader
    {
        public PlayerSave Load();
        public void Save(PlayerData playerData);
        public void ResetSave();
    }
}