using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)), Quaternion.identity);
    }
}
