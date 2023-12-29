using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    public Text scorelabel;
    public Colisions colisionsscript;
    // Start is called before the first frame update
    void Start()
    {
        colisionsscript = gameObject.GetComponent("colisionsgameobject").GetComponent<Colisions>();
    }
    
    void Update()
    {
        scorelabel.text = "Your high score is " + Colisions.score + "\n\nThank you for playing! \n\nGame by Renato and Tiago";
    }
}
