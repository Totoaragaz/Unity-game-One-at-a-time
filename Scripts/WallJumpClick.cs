using UnityEngine;

public class WallJumpClick : MonoBehaviour
{
    public StarScript StarMode;
    public PlayerMode Mode;

    void OnMouseDown()
    {
        if (StarMode.StarChoice)
        {
            FindObjectOfType<AudioManager>().Play("ClickSound");
            Mode.Mode = 1;
            StarMode.ChoiceMade = true;
        }
    }
}
