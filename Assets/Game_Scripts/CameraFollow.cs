using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;
    public GameObject player;

    void Start()
    {
        playerTarget = player.transform;
    }
    void Update()
    {
        transform.position = new Vector3(playerTarget.position.x, transform.position.y, playerTarget.position.z);
    }

}