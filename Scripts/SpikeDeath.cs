using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    public GameManager gameManager;
    public StarScript Star;

    void OnTriggerEnter2D()
    {
        if (Star.StarChoice==false) gameManager.Restart();
    }
}
