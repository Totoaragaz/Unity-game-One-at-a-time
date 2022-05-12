using UnityEngine;

public class PickaxeClick : MonoBehaviour
{
    public StarScript StarMode;
    public PlayerMode Mode;

    void OnMouseDown()
    {
        if (StarMode.StarChoice)
        {
            FindObjectOfType<AudioManager>().Play("ClickSound");
            Mode.Mode = 3;
            StarMode.ChoiceMade = true;
        }
    }
}
