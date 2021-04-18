using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    public static SwimSoundManager Instance;
    public KeyCode LeftArm;
    public KeyCode RightArm;
    public float swimspeed; 
    public float torqueMultiplier; 
    private Rigidbody _rb;
    //public static SwimGameManager Instance;

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
        if (Input.GetKeyDown(LeftArm))
        {
            _rb.AddRelativeForce(Vector3.right * swimspeed);
            //Twist Right
            _rb.AddTorque(new Vector3(0, 1, 0) * torqueMultiplier);

            if (SwimSoundManager.Instance != null)
            {
                SwimSoundManager.Instance.Swim.Play();
            }
        }

        else if (Input.GetKeyDown(RightArm))
        {
            _rb.AddRelativeForce(Vector3.right * swimspeed);
            //Twist Left 
            _rb.AddTorque(new Vector3(0, -1, 0) * torqueMultiplier);

            if (SwimSoundManager.Instance != null)
            {
                SwimSoundManager.Instance.Swim.Play();
            }
        }

        SwimHUD.Instance.UpdateFillBar(transform.position.x);
    }
}

