using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);

        if (other.gameObject.tag == "Player")
        {
            Instantiate(Resources.Load("Explosion") as GameObject, other.transform.position, transform.rotation, null);
            Destroy(other.gameObject);

            print("LASER HIT");
        }
    }
}
