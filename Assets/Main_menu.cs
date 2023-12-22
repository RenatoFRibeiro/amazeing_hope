using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play!");
        SceneManager.LoadScene("Level1");
    }
    public void Credits()
    {
        Debug.Log("Credits!");
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
