using UnityEngine;

public class DashLevelTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D()
    {
        PlayerPrefs.SetInt("Level5Complete", 1);
        gameManager.DashLevel();
    }
}
