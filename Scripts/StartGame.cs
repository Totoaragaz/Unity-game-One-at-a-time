using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SFXSlider;
    private bool FirstStart=true;

    public void Awake()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.25f);
    }

    public void StartLevel1()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        PlayerPrefs.DeleteKey("LevelComplete");
        PlayerPrefs.DeleteKey("Level5Complete");
        PlayerPrefs.DeleteKey("KeyNumber");
        PlayerPrefs.DeleteKey("PlayerMode");
        PlayerPrefs.DeleteKey("WallKeyGot");
        PlayerPrefs.DeleteKey("DashKeyGot");
        PlayerPrefs.DeleteKey("PickaxeKeyGot");
        PlayerPrefs.DeleteKey("DirtDug");
        PlayerPrefs.SetFloat("ElapsedTime",0f);
        PlayerPrefs.SetInt("TimerGoing", 1);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetHighScore()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        PlayerPrefs.DeleteKey("HighScore");
    }

    public void PlayClickSound()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
    }

    public void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

}
