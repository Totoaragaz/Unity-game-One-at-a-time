using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    public bool KeyGot=false;
    public int KeyDestroy = 0;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            KeyDestroy = PlayerPrefs.GetInt("WallKeyGot", 0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            KeyDestroy = PlayerPrefs.GetInt("DashKeyGot", 0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            KeyDestroy = PlayerPrefs.GetInt("PickaxeKeyGot", 0);
        }
        if (KeyDestroy == 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D()
    {
        FindObjectOfType<AudioManager>().Play("KeySound");
        Destroy(gameObject);
        KeyGot = true;
    }
}
