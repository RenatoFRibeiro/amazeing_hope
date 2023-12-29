using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
    public Text scorelabel;
    public Colisions colisionsscript;
    void Start()
    {
        colisionsscript = gameObject.GetComponent("colisionsgameobject").GetComponent<Colisions>();
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        print("Resume");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        print("Return to Main Menu");
        Time.timeScale = 1f;
        isPaused = false;
        Colisions.score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }
}
