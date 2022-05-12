using UnityEngine;

public class SpikeDeathNoStar : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D()
    {
        gameManager.Restart();
    }
}
