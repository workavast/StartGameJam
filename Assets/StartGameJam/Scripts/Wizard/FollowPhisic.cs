using UnityEngine;

public class FollowPhisic : MonoBehaviour
{
    public GameObject PhisicPl;

    private void FixedUpdate()
    {
        Transform tr = PhisicPl.transform;
        transform.position = new Vector3(tr.position.x, tr.position.y + 0.68f, transform.position.z);
    }
}
