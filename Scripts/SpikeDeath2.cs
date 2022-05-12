using UnityEngine;

public class SpikeDeath2 : MonoBehaviour
{
    public GameManager gameManager;
    public StarScript Star;
    public StarScript Star2;

    void OnTriggerEnter2D()
    {
        if (Star.StarChoice == false && Star2.StarChoice == false) gameManager.Restart();
    }
}
