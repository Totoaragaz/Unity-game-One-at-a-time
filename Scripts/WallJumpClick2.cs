using UnityEngine;

public class WallJumpClick2 : MonoBehaviour
{
    public StarScript Star;
    public StarScript Star2;
    public PlayerMode Mode;

    void OnMouseDown()
    {
        if (Star.StarChoice || Star2.StarChoice)
        {
            FindObjectOfType<AudioManager>().Play("ClickSound");
            Mode.Mode = 1;
            Star.ChoiceMade = true;
        }
    }
}
