using UnityEngine;
using UnityEngine.SceneManagement;

public class Colisions : MonoBehaviour
{
    public CameraFade cameraFaderscript;
    public AudioSource audioSourceB;
    public AudioClip audioClipB;
    public AudioClip audioClipE;
    public AudioClip audioClipW;
    public static float score = 0;
    public float volume;
    public void Start()
    {
        audioSourceB = GameObject.FindGameObjectWithTag("audioSourceB").GetComponent<AudioSource>();
        cameraFaderscript = GameObject.FindGameObjectWithTag("camerafade").GetComponent<CameraFade>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sound_event")
        {
            print("Hope event!");
            //add hope points
            score += 10;
            print("Score: "+ score);
            audioSourceB.PlayOneShot(audioClipE, volume);
        }else if (other.gameObject.tag == "Battery_event")
        {
            print("Battery event!");
            score += 10;
            print("Score: "+ score);
            //add fade time
            cameraFaderscript.ResetFadeAlpha();
            audioSourceB.PlayOneShot(audioClipB, volume);
        }else if (other.gameObject.tag == "Win_event")
        {
            print("Win event!");
            audioSourceB.PlayOneShot(audioClipW, volume);
        }else if (other.gameObject.tag == "Hell")
        {
            print("DIED FROM FALLING!");
            Application.Quit();
            score = 0;
            SceneManager.LoadScene("Menu");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sound_event")
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.tag == "Battery_event")
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.tag == "Win_event")
        { 
            print("Level UP!");
            score += 50;
            //wait one second
            //Thread.Sleep(1000);
            SceneManager.LoadScene("Level2");
        }
    }

}
