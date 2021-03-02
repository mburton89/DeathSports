using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pitcher : MonoBehaviour
{
    public Transform targetPlayer;
    public GameObject autoAimBallPrefab;
    public float hitSpeed;
    public float yForce;
    public float SpawnTime = 3f;

    private void Start()
    {
        StartCoroutine(BaseballGenerator());
    }

    IEnumerator BaseballGenerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            HitBallAtTarget();
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
