using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartBaseball : MonoBehaviour
{
    public void LoadBaseball()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
