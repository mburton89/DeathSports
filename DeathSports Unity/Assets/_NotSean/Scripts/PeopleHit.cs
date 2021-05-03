using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeopleHit : MonoBehaviour
{
    public static PeopleHit Instance;

    public int scoreValue;
    TextMeshProUGUI score;
    private int _maxScore;
    public GameObject RestartMenu;

    void Start()
    {
        Instance = this;
        scoreValue = 0;
        score = GetComponent<TextMeshProUGUI>();
        _maxScore = FindObjectsOfType<AutoAimTarget>().Length;
    }

    public void AddPoint()
    {
        scoreValue++;
        score.text = "People Hit:  " + scoreValue;
        if (scoreValue >= _maxScore)
        {
            Time.timeScale = 0;
            RestartMenu.SetActive(true);
        }
    }
}
