using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerPos;
    private int LevelComplete = 0;
    private int Level5Complete = 0;
    
    public PlayerMovement pm;
    public PlayerMode pmode;
    public Rigidbody2D PlayerRigidbody;
    
    public Vector3 LevelCompletePosition;
    public Vector2 EnterForce;
    public Vector3 LevelCompletePosition2;
    public Vector2 EnterForce2;
    public Vector3 LevelCompletePosition3;
    
    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject Gate3;
    public GameObject DeathScreen;
    
    public Text timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime = 0f;

    void Start()
    {
        elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        if (PlayerPrefs.GetInt("TimerGoing", 0) == 1) timerGoing = true;
        StartCoroutine(UpdateTimer());

        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            LevelComplete = PlayerPrefs.GetInt("LevelComplete", 0);
            if (LevelComplete == 1)
            {
                pm.LevelEnter(-EnterForce);
                PlayerPos.position = LevelCompletePosition;
            }
            else pm.LevelEnter(EnterForce);
        }
        else
        {
            Level5Complete = PlayerPrefs.GetInt("Level5Complete", 0);
            if (Level5Complete == 1)
            {
                pm.LevelEnter(-EnterForce);
                PlayerPos.position = LevelCompletePosition;
            }
            else if (Level5Complete == 2)
            {
                pm.LevelEnter(EnterForce2);
                PlayerPos.position = LevelCompletePosition2;
            }
            else if (Level5Complete == 3)
            {
                PlayerPos.position = LevelCompletePosition3;
            }
            else pm.LevelEnter(EnterForce);

            if (PlayerPrefs.GetInt("KeyNumber", 0)==1)
            {
                Destroy(Gate1);
            }
            else if (PlayerPrefs.GetInt("KeyNumber", 0) == 2)
            {
                Destroy(Gate1);
                Destroy(Gate2);
            }
            else if (PlayerPrefs.GetInt("KeyNumber", 0) == 3)
            {
                Destroy(Gate1);
                Destroy(Gate2);
                Destroy(Gate3);
            }
        }
    }
 

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("DirtDug",0)!=SceneManager.GetActiveScene().buildIndex) PlayerPrefs.SetInt("DirtDug", PlayerPrefs.GetInt("DirtDug", 0)+1);
        PlayerPrefs.SetInt("LevelComplete", 0);
        PlayerPrefs.SetFloat("PlayerMode",pmode.Mode);
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
    }

    public void PreviousLevel()
    {
        PlayerPrefs.SetInt("LevelComplete", 1);
        PlayerPrefs.SetFloat("PlayerMode", pmode.Mode);
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1); 
    }

    void FixedUpdate(){
        if (Input.GetKey("r"))
            Restart();
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("DeathSound");
        PlayerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        DeathScreen.SetActive(true);
        Invoke("RestartLevel", 0.2f);
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Level5()
    {
        PlayerPrefs.SetFloat("PlayerMode", pmode.Mode);
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        SceneManager.LoadScene(5);
    }

    public void WallJumpLevel()
    {
        PlayerPrefs.SetFloat("PlayerMode", pmode.Mode);
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        SceneManager.LoadScene(8);
    }
    
    public void DashLevel()
    {
        PlayerPrefs.SetFloat("PlayerMode", pmode.Mode);
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        SceneManager.LoadScene(9);
    }

    public void PickaxeLevel()
    {
        if (PlayerPrefs.GetInt("DirtDug", 0) == 4) PlayerPrefs.SetInt("DirtDug", 5);
        PlayerPrefs.SetFloat("PlayerMode", pmode.Mode);
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        SceneManager.LoadScene(10);
    }
}
