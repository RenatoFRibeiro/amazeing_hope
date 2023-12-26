using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_eventSpawner : MonoBehaviour
{
    public GameObject Sound_event;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++){
            Instantiate(Sound_event, new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)), Quaternion.identity);
        }
    }
}
