using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuRotate : MonoBehaviour
{
    public float secondsRotating;
    public Vector3 rotation;
    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
        StartCoroutine(MenuRotateCo());
    }

    private IEnumerator MenuRotateCo()
    {
        _image.transform.DORotate(rotation, secondsRotating).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(secondsRotating);
        _image.transform.DORotate(-rotation, secondsRotating).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(secondsRotating);
        StartCoroutine(MenuRotateCo());
    }
}
