using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Battery_eventSpawner : MonoBehaviour
{
    public GameObject Battery_event;
    public MazeGenerator mazeGenerator;
    public int size;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        size = mazeGenerator.mazeVar * 2;
        for (int i = 0; i < size; i++){
            Instantiate(Battery_event, new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)), Quaternion.identity);
        }
    }
}
