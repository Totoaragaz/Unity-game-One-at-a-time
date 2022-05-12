using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Trigger : MonoBehaviour
{
    public GameManager gameManager;
    public KeyScript Key;

    void OnTriggerEnter2D()
    {
        if (Key.KeyGot)
        {
            int KeyNumber=PlayerPrefs.GetInt("KeyNumber", 0);
            PlayerPrefs.SetInt("KeyNumber", KeyNumber + 1);
            if (SceneManager.GetActiveScene().buildIndex == 8)
            {
                PlayerPrefs.SetInt("WallKeyGot", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                PlayerPrefs.SetInt("DashKeyGot", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                PlayerPrefs.SetInt("DirtDug", 10);
                PlayerPrefs.SetInt("PickaxeKeyGot", 1);
            }
        }
        gameManager.Level5();
    }
}

