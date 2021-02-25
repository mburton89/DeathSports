using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwimGameManager : MonoBehaviour
{
    public static SwimGameManager Instance;
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public void CompleteLevel()
    {
        Debug.Log("Level WON!");
        completeLevelUI.SetActive(true);
    }
    private void Awake()
    {
        Instance = this;
    }


    //public void EndGame()

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
