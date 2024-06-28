using UnityEngine;

public class FollowPhisic : MonoBehaviour
{
    public GameObject PhisicPl;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform tr = PhisicPl.transform;
        transform.position = new Vector3(tr.position.x, tr.position.y + 0.68f, tr.position.z);
    }
}
