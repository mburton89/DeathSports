using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwimGameManager : MonoBehaviour
{
    public static SwimGameManager Instance;
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public void CompleteLevel()
    {
        Debug.Log("Level WON!");
        completeLevelUI.SetActive(true);
    }

 

    public void EndGame()
    {
       if (gameHasEnded == true)
        {
           gameHasEnded = true;
           print("Game Over!");
           Invoke("Restart Game", restartDelay);
        }
    }
    public void Restart()
    {
        StartCoroutine(RestartCo());
    }

    private IEnumerator RestartCo()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
