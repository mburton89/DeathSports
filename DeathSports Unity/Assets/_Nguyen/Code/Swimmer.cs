﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    public static SwimSoundManager Instance;
    public KeyCode LeftArm;
    public KeyCode RightArm;
    public KeyCode ForwardArms;
    public float swimspeed; 
    public float torqueMultiplier; 
    private Rigidbody _rb;
    //public static SwimGameManager Instance;

    [SerializeField] private Animator swimAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void CompleteLevel()
    {
        print("You Won!");
    }    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(LeftArm) || Input.GetKeyDown(KeyCode.A))
        {
            //_rb.AddRelativeForce(Vector3.right * swimspeed);
            //Twist Right
            _rb.AddTorque(new Vector3(0, -1, 0) * torqueMultiplier);

            if (SwimSoundManager.Instance != null)
            {
                SwimSoundManager.Instance.Swim.Play();
            }
        }

        else if (Input.GetKeyDown(RightArm) || Input.GetKeyDown(KeyCode.D))
        {
            //_rb.AddRelativeForce(Vector3.right * swimspeed);
            //Twist Left 
            _rb.AddTorque(new Vector3(0, 1, 0) * torqueMultiplier);

            if (SwimSoundManager.Instance != null)
            {
                SwimSoundManager.Instance.Swim.Play();
            }
        }

        else if (Input.GetKeyDown(ForwardArms) || Input.GetKeyDown(KeyCode.W))
        {
            _rb.AddRelativeForce(Vector3.right * swimspeed);

            if (SwimSoundManager.Instance != null)
            {
                SwimSoundManager.Instance.Swim.Play();
            }
        }

        print(_rb.velocity.magnitude);
        if (_rb.velocity.magnitude > 1)
        {
            swimAnimation.speed = 1;
        }
        else
        {
            swimAnimation.speed = 0.4f;
        }

        SwimHUD.Instance.UpdateFillBar(transform.position.x);
    }

}

