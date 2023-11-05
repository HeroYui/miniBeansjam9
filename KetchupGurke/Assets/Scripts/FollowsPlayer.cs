using UnityEngine;

public class FollowsPlayer : MonoBehaviour
{
    private PlayerController playerController;

    void Awake()
    {
        playerController = transform.parent.GetComponentInChildren<PlayerController>();
    }


    void FixedUpdate()
    {
        var playerTransformPosition = playerController.transform.position;
        transform.position = new Vector3(playerTransformPosition.x, playerTransformPosition.y, -10.0f);
    }

}
