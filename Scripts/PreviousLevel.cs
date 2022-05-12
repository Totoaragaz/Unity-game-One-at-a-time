using UnityEngine;

public class PreviousLevel : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D()
    {
        gameManager.PreviousLevel();
    }
}
