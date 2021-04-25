using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleMainMenu : MonoBehaviour
{
    public Button hurdlesButton;
    public Button baseballButton;
    public Button swimmingButton;

    void Start()
    {
        hurdlesButton.onClick.AddListener(LoadHurdles);
        baseballButton.onClick.AddListener(LoadBaseball);
        swimmingButton.onClick.AddListener(LoadSwimming);
    }

    void LoadHurdles()
    {
        SceneManager.LoadScene(1);
    }

    void LoadBaseball()
    {
        SceneManager.LoadScene(2);
    }

    void LoadSwimming()
    {
        SceneManager.LoadScene(3);
    }
}
