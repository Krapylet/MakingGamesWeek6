using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip bgm1;
    public AudioClip bgm2;
    public AudioClip bgm3;
    public AudioClip bgm4;
    public AudioClip bgm5;
    public AudioClip bgm6;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (SceneManager.GetActiveScene().name == "LevelTest" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bgm1);
        }
        else if (SceneManager.GetActiveScene().name == "LevelTest2" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bgm2);
        }
        else if (SceneManager.GetActiveScene().name == "LevelTest3" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bgm3);
        }
        else if (SceneManager.GetActiveScene().name == "LevelTest4" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bgm4);
        }
        else if (SceneManager.GetActiveScene().name == "LevelTest5" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bgm5);
        }
        else if (SceneManager.GetActiveScene().name == "StartMenu" && !audioSource.isPlaying)
        {
            Debug.Log("ueue");
            audioSource.PlayOneShot(bgm6);
        }
        else if (SceneManager.GetActiveScene().name == "EndCutScene" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bgm6);
        }
    }


}
