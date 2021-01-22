using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    //public Rigidbody Ball;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-15, 20), Random.Range(-15, 20), Random.Range(1, 50));
        }
        //Ball.velocity = new Vector3(Random.Range(-15, 20), Random.Range(1, 15), Random.Range(1, 40));
    }
}

