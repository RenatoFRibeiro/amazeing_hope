using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundColisions : MonoBehaviour
{
    // Enter the hitbox of the object to play the sound
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sound_event")
        {
            print("AI JESUS!");
            //GetComponent<AudioSource>().Play();
        }else if (other.gameObject.tag == "Battery_event")
        {
            print("Que se me apaga a luz!");
            //GetComponent<AudioSource>().Play();
        }else if (other.gameObject.tag == "Win_event")
        {
            print("CAPUT!");
            //GetComponent<AudioSource>().Play();
        }
    }
}
