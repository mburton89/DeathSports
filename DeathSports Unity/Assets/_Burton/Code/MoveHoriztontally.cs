using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHoriztontally : MonoBehaviour
{
    public Vector3 movementDirection;
    public float movementSpeed;
    public float maxXPosition;

    public void Init(int xDirection, float movementSpeed)
    {
        movementDirection = new Vector3(xDirection, 0, 0);
        this.movementSpeed = movementSpeed;
    }

    void Update()
    {
        transform.Translate((movementDirection * movementSpeed) * Time.deltaTime);
        if (transform.position.x > maxXPosition || transform.position.x < -maxXPosition)
        {
            Destroy(gameObject);
        }
    }
}
