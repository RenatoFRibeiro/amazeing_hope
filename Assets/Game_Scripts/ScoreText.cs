using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
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
        scorelabel.text = "Score: " + Colisions.score;
    }
}
