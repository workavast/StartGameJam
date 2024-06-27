using TMPro;
using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.UI.Elements
{
    public class FpsDropDown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropdown;

        [Inject] private readonly FpsCapChanger _fpsCapChanger;
        
        private void Start()
        {
            dropdown.SetValueWithoutNotify(Init(_fpsCapChanger.FpsCap));
            dropdown.onValueChanged.AddListener(UpdateFpsCap);
        }
        
        private void UpdateFpsCap(int newValue)
        {
            switch (newValue)
            {
                case 0://60
                    _fpsCapChanger.SetFpsCap(60);
                    break;
                case 1://120
                    _fpsCapChanger.SetFpsCap(120);
                    break;
                case 2://144
                    _fpsCapChanger.SetFpsCap(144);
                    break;
                case 3://240
                    _fpsCapChanger.SetFpsCap(240);
                    break;
            }
        }

        private int Init(int fpsCap)
        {
            switch (fpsCap)
            {
                case 60://60
                    return 0;
                case 120://120
                    return 1;
                case 144://144
                    return 2;
                case 240://240
                    return 3;
                default:
                    return 0;
            }
        }
    }
}