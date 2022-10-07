using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter(Collider other)
    {
        bool playerReachedGoal = other.tag == "Player";

        if (playerReachedGoal)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
