using UnityEngine;

public class DashClick2 : MonoBehaviour
{
    public StarScript Star;
    public StarScript Star2;
    public PlayerMode Mode;

    void OnMouseDown()
    {
        if (Star.StarChoice || Star2.StarChoice)
        {
            FindObjectOfType<AudioManager>().Play("ClickSound");
            Mode.Mode = 2;
            Star.ChoiceMade = true;
        }
    }
}
