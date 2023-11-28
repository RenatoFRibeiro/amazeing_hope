using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_eventSpawner : MonoBehaviour
{
    public GameObject Battery_event;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++){
            Instantiate(Battery_event, new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)), Quaternion.identity);
        }
    }
}
