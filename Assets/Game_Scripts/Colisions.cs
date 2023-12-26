using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundColisions : MonoBehaviour
{
    public AudioSource audioSourceB;
    public AudioClip audioClipB;
    public AudioClip audioClipE;
    public AudioClip audioClipW;
    public float volume;
    public void Start()
    {
        audioSourceB = GameObject.FindGameObjectWithTag("audioSourceB").GetComponent<AudioSource>();
        // Automatically start the fade
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sound_event")
        {
            print("Sound event!");
            audioSourceB.PlayOneShot(audioClipE, volume);
        }else if (other.gameObject.tag == "Battery_event")
        {
            print("Battery event!");
            audioSourceB.PlayOneShot(audioClipB, volume);
        }else if (other.gameObject.tag == "Win_event")
        {
            print("Win event!");
            audioSourceB.PlayOneShot(audioClipW, volume);
        }else if (other.gameObject.tag == "Hell")
        {
            print("DIED FROM FALLING!");
            Application.Quit();
            SceneManager.LoadScene("Menu");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sound_event")
        {
            //...?
        }else if (other.gameObject.tag == "Battery_event")
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.tag == "Win_event")
        {
            print("Level UP!");
            SceneManager.LoadScene("Level2");
        }
    }
}
