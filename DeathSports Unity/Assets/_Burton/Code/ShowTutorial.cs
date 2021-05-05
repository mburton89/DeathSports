using System.Collections;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("showTutorial") == 1)
        {
            StartCoroutine(DestroyCo());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyCo()
    {
        yield return new WaitForSeconds(10);
        PlayerPrefs.SetInt("showTutorial", 0);
        Destroy(gameObject);
    }
}
