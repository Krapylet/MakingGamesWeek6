using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using TMPro;

public class Timer : MonoBehaviour
{

    public int timeLimit = 60;
    public float restartEffectDuration;
    public Volume gameOverEffect;
    public TMP_Text timerText;

    private float gameStartTimeStamp;

    // Start is called before the first frame update
    void Start()
    {
        gameStartTimeStamp = Time.time;

        float gameOverEffectStartTimeStamp = gameStartTimeStamp - restartEffectDuration;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateVFX();

        // Check if the time limit has been exeted
        bool timeLimitExeeded = Time.time > gameStartTimeStamp + timeLimit;
        if (timeLimitExeeded)
        {
            SceneManager.LoadScene("GameOverTestScene");
            gameStartTimeStamp = Time.time;
        }
    }

    private void UpdateVFX()
    {
        // increase weight of post processing
    }

    private void UpdateTimer()
    {
        int secondsLeft = Mathf.CeilToInt(gameStartTimeStamp + timeLimit - Time.time);
        timerText.text = secondsLeft.ToString();
    }
}
