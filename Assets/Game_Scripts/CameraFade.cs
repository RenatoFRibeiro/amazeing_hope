using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;

    public float alpha = 0f;
    public Texture2D texture;
    public int direction = 0;
    public float time = 0f;
    private int counter;
    public void Start()
    {
        // Automatically start the fade
        AutoStartFade();
        //Battery event
    }

    public void Update()
    {
        if (alpha == 1f){
            counter += 1;
            if (counter >= 10){
                Application.Quit();
                print("DEAD!");
            }
            print("Pitch Black! Dying soon!");
        }
    }

    public void OnGUI()
    {
        if (alpha > 0f)
        {
            GUI.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
            GUI.color = Color.white;
        }

        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);

            if (alpha <= 0f || alpha >= 1f)
            {
                direction = 0;
            }
        }
    }

    public void AutoStartFade()
    {
        alpha = startFadedOut ? 1f : 0f;
        time = startFadedOut ? 0f : 1f;
        direction = startFadedOut ? 1 : -1;
    }

    public void ResetFadeAlpha()
    {
        print("Reseting alpha!");
        alpha = 0f;
        time = 1f;
        direction = -1;
    }
}
