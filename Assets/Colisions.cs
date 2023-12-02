using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundColisions : MonoBehaviour
{
    public CameraFade cameraFade;
    public void Start()
    {
        // Automatically start the fade
        cameraFade = GameObject.Find("MainCamera").GetComponent<CameraFade>();
    }
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

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sound_event")
        {
            //print("AI JESUS!");
            //GetComponent<AudioSource>().Play();
        }else if (other.gameObject.tag == "Battery_event")
        {
            Destroy(other.gameObject);
            print("Pilha com os cucos");
            cameraFade.ResetFadeAlpha();

        }else if (other.gameObject.tag == "Win_event")
        {
            print("WIN!");
            SceneManager.LoadScene("Level2");
            //GetComponent<AudioSource>().Play();
        }
    }
}
