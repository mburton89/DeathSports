using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleMainMenu : MonoBehaviour
{
    public Button hurdlesButton;
    public Button baseballButton;
    public Button swimmingButton;
    public Button creditsButton;
    public Button backButton;
    public GameObject menuContainer;
    public GameObject creditsContainer;

    void Start()
    {
        hurdlesButton.onClick.AddListener(LoadHurdles);
        baseballButton.onClick.AddListener(LoadBaseball);
        swimmingButton.onClick.AddListener(LoadSwimming);
        creditsButton.onClick.AddListener(OpenCredits);
        backButton.onClick.AddListener(GoBack);
    }

    void LoadHurdles()
    {
        SceneManager.LoadScene(1);
    }

    void LoadBaseball()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    void LoadSwimming()
    {
        SceneManager.LoadScene(3);
    }

    void OpenCredits()
    {
        menuContainer.transform.localScale = Vector3.zero;
        creditsContainer.transform.localScale = Vector3.one;
    }

    void GoBack()
    {
        menuContainer.transform.localScale = Vector3.one;
        creditsContainer.transform.localScale = Vector3.zero;
    }
}
