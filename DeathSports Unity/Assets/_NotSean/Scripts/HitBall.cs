using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBall : MonoBehaviour
{
    public Rigidbody Ball;
    public Image powerMeter;
    public float forceMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, forceMultiplier * powerMeter.fillAmount);
        }
    }
}

