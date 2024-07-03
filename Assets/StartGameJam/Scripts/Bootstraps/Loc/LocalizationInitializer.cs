using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace StartGameJam.Scripts.Bootstraps.Loc
{
    public class LocalizationInitializer
    {
        private readonly ILocalizationInitializer _localizationInitializer = new AndroidLocalizationInitializer();
        
        public async Task InitLocalizationSettings()
        {
            var handleTask = LocalizationSettings.InitializationOperation;
            await handleTask.Task;

            int langIndex = 1;
            if (!PlayerData.PlayerData.Instance.LocalizationSettings.Initializaed)
                langIndex = _localizationInitializer.GetLocalization();
            else
                langIndex = PlayerData.PlayerData.Instance.LocalizationSettings.LocalizationId;
            
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[langIndex];
            
            var handleTask2 = LocalizationSettings.InitializationOperation;
            await handleTask2.Task;
            PlayerData.PlayerData.Instance.LocalizationSettings.ChangeLocalization(langIndex);
            PlayerData.PlayerData.Instance.LocalizationSettings.Initialize();

            Debug.Log("-||- LocalizationInitializer");
        }
    }
}
