using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "bat")
        {
            CameraFollowBall.Instance.ballHasBeenHit = false;
        }
    }
}
