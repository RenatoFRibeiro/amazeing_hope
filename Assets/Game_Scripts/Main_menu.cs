using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play!");
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
