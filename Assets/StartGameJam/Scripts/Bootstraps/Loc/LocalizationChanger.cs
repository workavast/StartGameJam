using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace StartGameJam.Scripts.Bootstraps.Loc
{
    public class LocalizationChanger
    {
        public int LocalizationIndex => PlayerData.PlayerData.Instance.LocalizationSettings.LocalizationId;
        
        private bool _active;
        
        public async void ChangeLocalization(int localizationId)
        {
            if(_active || PlayerData.PlayerData.Instance.LocalizationSettings.LocalizationId == localizationId)
                return;
            
            if (localizationId >= LocalizationSettings.AvailableLocales.Locales.Count || localizationId < 0)
            {
                Debug.LogError("Invalid localization Id");
                return;
            }
            
            await ApplyLocalization(localizationId);
            
            PlayerData.PlayerData.Instance.LocalizationSettings.ChangeLocalization(localizationId);
        }

        private async Task ApplyLocalization(int localizationId)
        {
            _active = true;

            var handleTask = LocalizationSettings.InitializationOperation;
            await handleTask.Task;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localizationId];
            
            _active = false;
        }
    }
}