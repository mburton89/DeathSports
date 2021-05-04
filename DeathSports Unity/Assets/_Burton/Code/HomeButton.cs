using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    private Button homeButton;

    void Start()
    {
        homeButton = GetComponent<Button>();
        homeButton.onClick.AddListener(GoHome);
    }

    void GoHome()
    {
        Time.timeScale = 1;
        if (HurdlesSoundManager.Instance != null)
        {
            Destroy(HurdlesSoundManager.Instance.gameObject);
        }
        if (SwimSoundManager.Instance != null)
        {
            Destroy(SwimSoundManager.Instance.gameObject);
        }
        SceneManager.LoadScene(0);
    }
}
