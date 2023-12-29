using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour
{
    public Text scorelabel;
    public Colisions colisionsscript;

    void Start()
    {
        colisionsscript = gameObject.GetComponent("colisionsgameobject").GetComponent<Colisions>();
    }
    public void PlayGame()
    {
        Debug.Log("Play Again!");
        Colisions.score = 0;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
