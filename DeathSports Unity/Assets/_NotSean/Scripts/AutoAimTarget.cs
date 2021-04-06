using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoAimTarget : MonoBehaviour
{
    private Vector3 _previousPosition;
    private Vector3 _currentPosition;
    public Vector3 directionMovingTowards;

    private void Update()
    {
        _previousPosition = _currentPosition;
        _currentPosition = transform.position;
        directionMovingTowards = (_currentPosition - _previousPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
            //Destroy(transform.parent.gameObject);
            PeopleHit.scoreValue++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
            //Destroy(transform.parent.gameObject);
            PeopleHit.scoreValue++;
        }
    }
}
