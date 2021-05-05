using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerBean : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 swimDirection;
    public float speed;
    public float rotationSpeed;
    public Vector3 rotateDirection;
    public GameObject leftArm;
    public GameObject rightArm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = swimDirection * speed;
        //rb.AddForce(swimDirection * speed * Time.deltaTime);
        leftArm.transform.Rotate(rotateDirection * rotationSpeed);
        rightArm.transform.Rotate(rotateDirection * rotationSpeed);
    }
}
