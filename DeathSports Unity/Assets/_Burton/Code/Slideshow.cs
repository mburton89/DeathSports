using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour
{
    public List<GameObject> billboards;
    public float secondsPerBillboard;

    void Start()
    {
        StartCoroutine(ShowSlides());
    }

    private IEnumerator ShowSlides()
    {
        for (int i = 0; i < billboards.Count; i++)
        {
            billboards[i].SetActive(false);
        }

        int rand = Random.Range(0, billboards.Count);
        billboards[rand].SetActive(true);
        yield return new WaitForSeconds(secondsPerBillboard);
        StartCoroutine(ShowSlides());
    }
}
