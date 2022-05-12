using UnityEngine;
using UnityEngine.SceneManagement;

public class DirtDigging : MonoBehaviour
{
    public Transform Player;
    public Transform DirtBlock;
    public PlayerMode pmode;

    void Start()
    {
        if (PlayerPrefs.GetInt("DirtDug", 0) >= SceneManager.GetActiveScene().buildIndex)
        {
            Destroy(gameObject);
        }
    }

    bool Position()
    {
        if (Mathf.Abs(Player.position.x - DirtBlock.position.x) < 1.5 && Mathf.Abs(Player.position.y - DirtBlock.position.y) < 0.5) return true;
        else return false;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("space")){
            if (pmode.Mode==3 && Position())
            {
                FindObjectOfType<AudioManager>().Play("DirtSound");
                Destroy(gameObject);
            }
        }
    }
}
