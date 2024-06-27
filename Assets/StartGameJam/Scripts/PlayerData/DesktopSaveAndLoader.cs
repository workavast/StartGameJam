using Avastrad.SavingAndLoading;

namespace StartGameJam.Scripts.PlayerData
{
    public class DesktopSaveAndLoader : IPlayerDataSaveAndLoader
    {
        private readonly ISaveAndLoader _fileSaveAndLoader = new JsonSaveAndLoader();
        
        public PlayerSave Load() 
            => _fileSaveAndLoader.Load<PlayerSave>();

        public void Save(PlayerData playerData) 
            => _fileSaveAndLoader.Save(new PlayerSave(playerData));

        public void ResetSave() 
            => _fileSaveAndLoader.Save(new PlayerSave());
    }
}