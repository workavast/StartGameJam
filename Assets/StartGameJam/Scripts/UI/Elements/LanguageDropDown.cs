using StartGameJam.Scripts.Localization;
using TMPro;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Elements
{
    public class LocalizationDropDown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropdown;

        [Inject] private readonly LocalizationChanger _localizationChanger;
        
        private void Start()
        {
            dropdown.SetValueWithoutNotify(Init(LocalizationChanger.LocalizationIndex));
            dropdown.onValueChanged.AddListener(UpdateFpsCap);
        }
        
        private void UpdateFpsCap(int newValue)
        {
            switch (newValue)
            {
                case 0://English
                    _localizationChanger.ChangeLocalization(0);
                    break;
                case 1://Russian
                    _localizationChanger.ChangeLocalization(1);
                    break;
            }
        }

        private int Init(int fpsCap)
        {
            switch (fpsCap)
            {
                case 0://60
                    return 0;
                case 1://120
                    return 1;
                default:
                    return 0;
            }
        }
    }
}