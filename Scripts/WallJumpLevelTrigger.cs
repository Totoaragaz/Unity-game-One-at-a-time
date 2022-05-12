using UnityEngine;

public class WallJumpLevelTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D()
    {
        PlayerPrefs.SetInt("Level5Complete", 3);
        gameManager.WallJumpLevel();
    }
}
