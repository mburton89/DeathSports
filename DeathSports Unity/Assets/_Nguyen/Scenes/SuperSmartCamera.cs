using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSmartCamera : MonoBehaviour
{
    public Transform _target;

    void Update()
    {
        transform.position = new Vector3(_target.position.x, transform.position.y, transform.position.z);
    }
}
