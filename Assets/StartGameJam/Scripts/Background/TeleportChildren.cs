using UnityEngine;

public class TeleportChildren : MonoBehaviour
{
    
    // �������� �� ������ ������ �� ������� �����
    private float boundaryOffset = 18f;
    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // ���������� ������� ����� �� ������ ��������� ������
        float leftBoundary = mainCamera.transform.position.x - boundaryOffset;

        // �������� ��� �������� �������
        Transform[] children = GetComponentsInChildren<Transform>();

        // �������������� ���������� ��� �������� �������� ������ � ������� ��������
        Transform leftMost = null;
        Transform rightMost = null;

        // ���������� �� ���� �������� ��������
        foreach (Transform child in children)
        {
            if (child == transform) continue; // ���������� ������������ ������

            // ��������� ������� ����� ������
            if (leftMost == null || child.position.x < leftMost.position.x)
            {
                leftMost = child;
            }

            // ��������� ������� ������ ������
            if (rightMost == null || child.position.x > rightMost.position.x)
            {
                rightMost = child;
            }
        }

        // ���������, ���� ������� ����� ������ ����� �� ������� �����
        if (leftMost != null && leftMost.position.x < leftBoundary)
        {
            // ���������� ������� ����� ������ �� ������� ������
            float width = rightMost.GetComponent<Renderer>().bounds.size.x;
            leftMost.position = new Vector3(rightMost.position.x + width, leftMost.position.y, leftMost.position.z);
        }
    }
}