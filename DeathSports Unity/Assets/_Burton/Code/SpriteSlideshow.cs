using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSlideshow : MonoBehaviour
{
    public List<Sprite> sprites;
    public Image image;
    public float secondsPerBillboard; 

    void Start()
    {
        StartCoroutine(ShowSlides());
    }

    private IEnumerator ShowSlides()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            image.sprite = sprites[i];
        }
        yield return new WaitForSeconds(secondsPerBillboard);
        StartCoroutine(ShowSlides());
    }
}
