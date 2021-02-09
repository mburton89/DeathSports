using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHoriztontally : MonoBehaviour
{
    public Vector3 _movementDirection;
    public float _movementSpeed;
    public float maxXPosition;

    public void Init(int xDirection, float movementSpeed)
    {
        _movementDirection = new Vector3(xDirection, 0, 0);
        _movementSpeed = movementSpeed;
    }

    void Update()
    {
        transform.Translate((_movementDirection * _movementSpeed) * Time.deltaTime);
        if (transform.position.x > maxXPosition || transform.position.x < -maxXPosition)
        {
            Destroy(gameObject);
        }
    }
}
