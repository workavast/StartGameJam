using UnityEngine;

namespace StartGameJam.Scripts
{
    public class MouesOffseter : MonoBehaviour
    {
        [SerializeField] private float offsetPowerX;
        [SerializeField] private float offsetPowerY;
        
        private void Update()
        {
            var screenSize = new Vector2(Screen.width, Screen.height);
            Vector2 mousePosition = Input.mousePosition;

            var fixedMouse = mousePosition - screenSize / 2;
            var offsetPercentageX = fixedMouse.x / screenSize.x / 2;
            var offsetPercentageY = fixedMouse.y / screenSize.y / 2;

            var offsetByX = Vector3.right * (offsetPercentageX * offsetPowerX);
            var offsetByY = Vector3.up * (offsetPercentageY  * offsetPowerY);
            var newPosition = offsetByX + offsetByY;
            newPosition.z = transform.position.z;
            
            transform.position = newPosition;
        }
    }
}