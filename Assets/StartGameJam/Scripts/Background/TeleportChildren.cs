using UnityEngine;

public class TeleportChildren : MonoBehaviour
{
    
    // Смещение от центра камеры до границы сцены
    private float boundaryOffset = 18f;
    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Определяем границы сцены на основе положения камеры
        float leftBoundary = mainCamera.transform.position.x - boundaryOffset;

        // Получаем все дочерние объекты
        Transform[] children = GetComponentsInChildren<Transform>();

        // Инициализируем переменные для хранения крайнего левого и правого объектов
        Transform leftMost = null;
        Transform rightMost = null;

        // Проходимся по всем дочерним объектам
        foreach (Transform child in children)
        {
            if (child == transform) continue; // Пропускаем родительский объект

            // Обновляем крайний левый объект
            if (leftMost == null || child.position.x < leftMost.position.x)
            {
                leftMost = child;
            }

            // Обновляем крайний правый объект
            if (rightMost == null || child.position.x > rightMost.position.x)
            {
                rightMost = child;
            }
        }

        // Проверяем, если крайний левый объект вышел за пределы сцены
        if (leftMost != null && leftMost.position.x < leftBoundary)
        {
            // Перемещаем крайний левый объект за крайний правый
            float width = rightMost.GetComponent<Renderer>().bounds.size.x;
            leftMost.position = new Vector3(rightMost.position.x + width, leftMost.position.y, leftMost.position.z);
        }
    }
}