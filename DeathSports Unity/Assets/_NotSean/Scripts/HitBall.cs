using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    //Use this without spawn script
    //public Rigidbody Ball;

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Ball.velocity = new Vector3(Random.Range(-15, 20), Random.Range(1, 15), Random.Range(1, 40));
    //}


    public Rigidbody Ball;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("HIT");
        Ball.velocity = new Vector3(0,1,10);
    }
}

