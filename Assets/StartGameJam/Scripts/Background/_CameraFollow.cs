using UnityEngine;

public class _CameraFollow : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}