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

    private bool gameHasStarted = true;
    private float gameStartTimeStamp;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHasStarted)
        {
            UpdateTimer();
        }

        UpdateVFX();
        CheckTimeLimit();
    }

    private void CheckTimeLimit()
    {
        // Check if the time limit has been exeted
        bool timeLimitExeeded = Time.time > gameStartTimeStamp + timeLimit;
        if (timeLimitExeeded)
        {
            gameHasStarted = false;
            gameStartTimeStamp = Time.time;
            SceneManager.LoadScene("StartMenu");
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

    public void StartGame()
    {
        StartCoroutine(LoadLevel1Async());
    }

    IEnumerator LoadLevel1Async()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelTest");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // After the scene has loaded, enable the timer
        gameHasStarted = true;
        timerText.gameObject.SetActive(true);
        gameStartTimeStamp = Time.time;
    }
}
