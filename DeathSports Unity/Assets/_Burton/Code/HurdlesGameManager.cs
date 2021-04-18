using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HurdlesGameManager : MonoBehaviour
{
    public static HurdlesGameManager Instance;

    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    private int _currentScore;

    void Awake()
    {
        //Time.timeScale = .5f;
        Instance = this;
    }

    void Start()
    {
        _highScoreText.SetText(PlayerPrefs.GetInt("HurdlesHighScore").ToString());
        _currentScore = 0;
    }

    public void Restart()
    {
        StartCoroutine(RestartCo());
    }

    private IEnumerator RestartCo()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddPoint()
    {
        _currentScore++;
        _currentScoreText.SetText(_currentScore.ToString());

        if (_currentScore > PlayerPrefs.GetInt("HurdlesHighScore"))
        {
            PlayerPrefs.SetInt("HurdlesHighScore", _currentScore);
            _highScoreText.SetText(_currentScore.ToString());
        }
    }
}
