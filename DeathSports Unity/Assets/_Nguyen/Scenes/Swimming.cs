using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public KeyCode LeftArm;
    public KeyCode RightArm;
    public float swimspeed; 
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(LeftArm))
        {
            _rb.AddRelativeForce(Vector3.right * swimspeed);
            //Twist Right
            _rb.AddTorque(new Vector3(0, 1, 0));
        }

        else if (Input.GetKeyDown(RightArm))
        {
            _rb.AddRelativeForce(Vector3.right * swimspeed);
            //Twist Left 
            _rb.AddTorque(new Vector3(0, -1, 0));
        }
    }
}
