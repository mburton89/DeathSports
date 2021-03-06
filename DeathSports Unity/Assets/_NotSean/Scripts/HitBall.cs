﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBall : MonoBehaviour
{
    public Image powerMeter;

    [HideInInspector] public AutoAimTarget[] autoAimTargets;

    public GameObject autoAimBallPrefab;
    public float hitSpeed;
    public float yForce;
    public float leadMultiplier;
    public GameObject MainCam;
    public GameObject BallCam;
    public int CamMode;
    public int BallSpeedFromBat;

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
        }
    }

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
        float newHitSpeed = (hitSpeed) + (powerMeter.fillAmount * BallSpeedFromBat);
        ballRigidbody.AddForce(directionToHit.normalized * (newHitSpeed / 1.3f));
        ballRigidbody.AddForce(Vector3.up * (yForce * Mathf.Abs(directionToHit.magnitude)));
        Destroy(ballToHit, 3);

        CameraFollowBall.Instance.LookAt(ballToHit.transform, newHitSpeed);
    }
}

