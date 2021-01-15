using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public Vector3 directionToRotate;
    public float rotationSpeed;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(directionToRotate * rotationSpeed * Time.deltaTime);
        }
        
    }
}
