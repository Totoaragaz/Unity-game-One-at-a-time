using UnityEngine;

public class PickaxeLevelTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D()
    {
        PlayerPrefs.SetInt("Level5Complete", 2);
        gameManager.PickaxeLevel();
    }
}
