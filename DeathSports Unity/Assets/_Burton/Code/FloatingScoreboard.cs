using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingScoreboard : MonoBehaviour
{
    [SerializeField] private Transform _propeller1;
    [SerializeField] private Transform _propeller2;
    [SerializeField] private Vector3 propellerRotation;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Ease ease;

    [SerializeField] private float _bobSpeed;
    [SerializeField] private float _bobDistance;
    private float _initialYPosition;

    void Start()
    {
        _initialYPosition = transform.position.y;
        StartCoroutine(BobCo());
    }

    private void Update()
    {
        _propeller1.Rotate(propellerRotation * _rotationSpeed * Time.deltaTime);
        _propeller2.Rotate(propellerRotation * _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(_initialYPosition + _bobDistance, _bobSpeed, false).SetEase(ease);
        yield return new WaitForSeconds(_bobSpeed);
        transform.DOMoveY(_initialYPosition, _bobSpeed, false).SetEase(ease);
        yield return new WaitForSeconds(_bobSpeed);
        StartCoroutine(BobCo());
    }
}
