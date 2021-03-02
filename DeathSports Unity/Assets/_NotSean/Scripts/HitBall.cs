using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBall : MonoBehaviour
{
    //public Rigidbody Ball;
    public Image powerMeter;
    //public float forceMultiplier;

    public Transform[] target;
    private int randomTarget;

    //public Transform target;
    public GameObject autoAimBallPrefab;
    public float hitSpeed;
    public float yForce;
    public float leadMultiplier;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            HitBallAtTargetMultiple();
        }
    }

    /*void HitBallAtTarget()
    {
        //Figure out where Target will be
        Vector3 targetPosition = new Vector3();
        if (target.GetComponent<AutoAimTarget>())
        {
            float leadMultiplierMultiplier;
            leadMultiplierMultiplier = (target.position - transform.position).magnitude;
            targetPosition = target.position + (target.GetComponent<AutoAimTarget>().directionMovingTowards * (leadMultiplier * Mathf.Abs(leadMultiplierMultiplier)));
        }
        else
        {
            targetPosition = target.position;
        }

        Vector3 directionToHit = targetPosition - transform.position;
        GameObject newAutoAimBall = Instantiate(autoAimBallPrefab, transform.position, transform.rotation, null) as GameObject;
        newAutoAimBall.GetComponent<Rigidbody>().AddForce(directionToHit.normalized * hitSpeed * powerMeter.fillAmount);
        newAutoAimBall.GetComponent<Rigidbody>().AddForce(Vector3.up * (yForce * Mathf.Abs(directionToHit.magnitude)));
        Destroy(newAutoAimBall, 3);
    }*/

    void HitBallAtTargetMultiple()
    {
        Vector3 targetPosition = new Vector3();
        if (target[randomTarget].GetComponent<AutoAimTarget>())
        {
            float leadMultiplierMultiplier;
            leadMultiplierMultiplier = (target[randomTarget].position - transform.position).magnitude;
            targetPosition = target[randomTarget].position + (target[randomTarget].GetComponent<AutoAimTarget>().directionMovingTowards * (leadMultiplier * Mathf.Abs(leadMultiplierMultiplier)));
        }
        else
        {
            targetPosition = target[randomTarget].position;
        }

        Vector3 directionToHit = targetPosition - transform.position;
        GameObject newAutoAimBall = Instantiate(autoAimBallPrefab, transform.position, transform.rotation, null) as GameObject;
        newAutoAimBall.GetComponent<Rigidbody>().AddForce(directionToHit.normalized * hitSpeed * powerMeter.fillAmount);
        newAutoAimBall.GetComponent<Rigidbody>().AddForce(Vector3.up * (yForce * Mathf.Abs(directionToHit.magnitude)));
        Destroy(newAutoAimBall, 3);
    }
}