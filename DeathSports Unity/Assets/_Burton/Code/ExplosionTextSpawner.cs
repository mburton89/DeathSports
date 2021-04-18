using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExplosionTextSpawner : MonoBehaviour
{
    [SerializeField] private List<Sprite> _textSprites;
    [SerializeField] SpriteRenderer _text;
    [SerializeField] float _maxSize;
    [SerializeField] float _growDuration;
    [SerializeField] float _shakeAmount;
    [SerializeField] float _shakeDuration;

    Vector3 randVector3;

    void Start()
    {
        int rand = Random.Range(0, _textSprites.Count);
        _text.sprite = _textSprites[rand];

        int randZ = Random.Range(0, 360);
        randVector3 = new Vector3(0, 0, randZ);

        StartCoroutine(ShowTextCo());
    }

    private void Update()
    {
        transform.Rotate(randVector3 * .1f * Time.deltaTime);
    }

    private IEnumerator ShowTextCo()
    {
        _text.transform.DOLocalMoveY(4, 2);
        _text.transform.localScale = Vector3.zero;
        _text.transform.DOScale(_maxSize, _growDuration);
        yield return new WaitForSeconds(_growDuration);
        _text.transform.DOShakeScale(_shakeDuration, _shakeAmount, 10, 90, true);
        _text.transform.DOShakeRotation(_shakeDuration, _shakeAmount, 10, 90, true);
        _text.DOFade(0, _shakeDuration);
    }
}
