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

    private const string HIGH_SCORE_LABEL = "High Score: ";

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _highScoreText.SetText(HIGH_SCORE_LABEL + PlayerPrefs.GetInt("HurdlesHighScore"));
        _currentScore = 0;
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

    public void AddPoint()
    {
        _currentScore++;
        _currentScoreText.SetText(_currentScore.ToString());

        if (_currentScore > PlayerPrefs.GetInt("HurdlesHighScore"))
        {
            PlayerPrefs.SetInt("HurdlesHighScore", _currentScore);
            _highScoreText.SetText(HIGH_SCORE_LABEL + _currentScore);
        }
    }
}
