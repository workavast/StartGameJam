using UnityEngine;

namespace StartGameJam.Scripts.Localization
{
    public class WebLocalizationInitializer : ILocalizationInitializer
    {
        public int GetLocalization()
        {
            switch (Application.systemLanguage)
            {
                case SystemLanguage.Russian:
                    return 1;
                case SystemLanguage.Ukrainian:
                    return 1;
                default://English
                    return 0;
            }
        }
    }
}