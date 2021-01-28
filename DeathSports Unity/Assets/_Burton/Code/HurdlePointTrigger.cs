using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdlePointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hurdle")
        {
            HurdlesGameManager.Instance.AddPoint();
        }
    }
}
