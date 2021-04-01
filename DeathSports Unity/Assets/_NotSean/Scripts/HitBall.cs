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

    public GameObject MainCam;
    public GameObject BallCam;
    public int CamMode;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            HitBallAtTargetMultiple(other.gameObject);
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            //StartCoroutine(ToggleCamera());
        }
    }


    // No Array
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

    void HitBallAtTargetMultiple(GameObject ballToHit)
    {
        Rigidbody ballRigidbody = ballToHit.GetComponent<Rigidbody>();
        ballRigidbody.velocity = Vector3.zero;

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
        ballRigidbody.AddForce(directionToHit.normalized * hitSpeed * powerMeter.fillAmount);
        ballRigidbody.AddForce(Vector3.up * (yForce * Mathf.Abs(directionToHit.magnitude)));
        Destroy(ballToHit, 3);
    }

    /*IEnumerator ToggleCamera()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            MainCam.SetActive(true);
            BallCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            MainCam.SetActive(false);
            BallCam.SetActive(true);
        }
    }*/
}