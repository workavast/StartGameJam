using UnityEngine;

namespace StartGameJam.Scripts.Bootstraps.Loc
{
    public class AndroidLocalizationInitializer : ILocalizationInitializer
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