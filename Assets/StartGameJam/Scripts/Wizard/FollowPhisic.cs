using UnityEngine;

public class FollowPhisic : MonoBehaviour
{
    [SerializeField] private bool followX = true;
    [SerializeField] private bool followY = true;
    
    public GameObject PhisicPl;

    private void FixedUpdate()
    {
        var followedPosition = PhisicPl.transform.position;

        var newPosition = transform.position;

        if (followX)
            newPosition.x = followedPosition.x;
        
        if (followY)
            newPosition.y = followedPosition.y + 0.68f;
        
        transform.position = newPosition;
    }
}
