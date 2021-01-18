using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleObstacle : MonoBehaviour
{
    private Vector3 _movementDirection;
    private float _movementSpeed;

    public void Init(int xDirection, float movementSpeed)
    {
        _movementDirection = new Vector3 (xDirection, 0, 0);
        _movementSpeed = movementSpeed;
    }

    void Update()
    {
        transform.Translate((_movementDirection * _movementSpeed) * Time.deltaTime);
    }
}
