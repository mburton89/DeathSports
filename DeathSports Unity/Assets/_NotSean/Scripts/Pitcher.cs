using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pitcher : MonoBehaviour
{
    public Transform targetPlayer;
    public GameObject autoAimBallPrefab;
    public float hitSpeed;
    public float yForce;
    public float SpawnTime = 3f;
    public float startDelay = 0.5f;

    public Animator anim;

    void Start()
    {
        anim.Play("PitchIdle");

        StartCoroutine(BaseballGenerator());
        StartCoroutine(Animations());
    }

    IEnumerator BaseballGenerator()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            HitBallAtTarget();
            BallsPitchedCounter.scoreValue1++;
        }
    }

    IEnumerator Animations()
    {
        yield return new WaitForSeconds(SpawnTime);

        while (true)
        {
            anim.Play("PitcherPitch");          
            yield return new WaitForSeconds(SpawnTime / 2);
            anim.Play("PitchIdle");
        }
    }

    void HitBallAtTarget()
    {
        //Figure out where Target will be
        Vector3 targetPosition = new Vector3();
        if (targetPlayer.GetComponent<AutoAimTarget>())
        {
            float leadMultiplierMultiplier;
            leadMultiplierMultiplier = (targetPlayer.position - transform.position).magnitude;
            targetPosition = targetPlayer.position + (targetPlayer.GetComponent<AutoAimTarget>().directionMovingTowards * (Mathf.Abs(leadMultiplierMultiplier)));
        }
        else
        {
            targetPosition = targetPlayer.position;
        }

        Vector3 directionToHit = targetPosition - transform.position;
        GameObject newAutoAimBall = Instantiate(autoAimBallPrefab, transform.position, transform.rotation, null) as GameObject;
        newAutoAimBall.GetComponent<Rigidbody>().AddForce(directionToHit.normalized * hitSpeed);
        newAutoAimBall.GetComponent<Rigidbody>().AddForce(Vector3.up * (yForce * Mathf.Abs(directionToHit.magnitude)));
    }
}
