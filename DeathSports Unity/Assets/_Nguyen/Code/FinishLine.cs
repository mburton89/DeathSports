using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour

{
    public GameObject Goal;
    private void OnTriggerEnter(Collider collision)
    {
      //GameObject hitbox = Collider.gameObject;
        print("YOU WIN");

    }
}
