using UnityEngine;

public class DashClick : MonoBehaviour
{
    public StarScript StarMode;
    public PlayerMode Mode;

    void OnMouseDown()
    {
        if (StarMode.StarChoice)
        {
            FindObjectOfType<AudioManager>().Play("ClickSound");
            Mode.Mode = 2;
            StarMode.ChoiceMade = true;
        }
    }
}
