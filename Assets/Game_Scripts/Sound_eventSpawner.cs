using UnityEngine;

public class Sound_eventSpawner : MonoBehaviour
{
    public GameObject Sound_event;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public int multiplier;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < multiplier; i++){
            Instantiate(Sound_event, new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)), Quaternion.identity);
        }
    }
}
