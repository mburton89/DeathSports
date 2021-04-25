using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBall : MonoBehaviour
{
    //public Rigidbody Ball;
    public Image powerMeter;
    //public float forceMultiplier;

    [HideInInspector] public AutoAimTarget[] autoAimTargets;

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
        BaseballSoundManager.Instance.baseballhit.Play();

        Rigidbody ballRigidbody = ballToHit.GetComponent<Rigidbody>();
        ballRigidbody.velocity = Vector3.zero;

        Vector3 targetPosition = new Vector3();

        autoAimTargets = FindObjectsOfType<AutoAimTarget>();
        int randomTargetIndex = Random.Range(0, autoAimTargets.Length);

        float leadMultiplierMultiplier;
        leadMultiplierMultiplier = (autoAimTargets[randomTargetIndex].transform.position - transform.position).magnitude;
        targetPosition = autoAimTargets[randomTargetIndex].transform.position + (autoAimTargets[randomTargetIndex].GetComponent<AutoAimTarget>().directionMovingTowards * (leadMultiplier * Mathf.Abs(leadMultiplierMultiplier)));

        Vector3 directionToHit = targetPosition - transform.position;
        float newHitSpeed = (hitSpeed) + (powerMeter.fillAmount * 5000);
        ballRigidbody.AddForce(directionToHit.normalized * newHitSpeed);
        ballRigidbody.AddForce(Vector3.up * (yForce * Mathf.Abs(directionToHit.magnitude)));
        Destroy(ballToHit, 3);

        CameraFollowBall.Instance.LookAt(ballToHit.transform, newHitSpeed);
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