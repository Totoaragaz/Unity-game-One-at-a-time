using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    private float NewTime;
    private TimeSpan timePlaying;
    public Text NewTimeText;
    public Text HighScoreText;
    private float HighScore;
    public GameObject HighScoreBeater;

    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("WinSound");
    }
    void Start()
    {
        PlayerPrefs.SetInt("TimerGoing", 0);
        NewTime = PlayerPrefs.GetFloat("ElapsedTime", 0);
        HighScore = PlayerPrefs.GetFloat("HighScore", 99999999);
        if (NewTime < HighScore)
        {
            HighScoreBeater.SetActive(true);
            PlayerPrefs.SetFloat("HighScore", NewTime);
            HighScore = NewTime;
        }
            timePlaying = TimeSpan.FromSeconds(NewTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            NewTimeText.text = timePlayingStr;
            timePlaying = TimeSpan.FromSeconds(HighScore);
            timePlayingStr = "High Score: " + timePlaying.ToString("mm':'ss'.'ff");
            HighScoreText.text = timePlayingStr;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
