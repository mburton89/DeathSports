using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    // Use this without respawn balls
    public Vector3 directionToRotate;
    public float rotationSpeed;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.Rotate(directionToRotate * rotationSpeed * Time.deltaTime);
        }
    }
}
