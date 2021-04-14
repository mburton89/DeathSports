using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    // Use this without respawn balls
    public Vector3 directionToRotate;
    public float rotationSpeed;
    public float delayTime = 1.0f;

    // If anyone looks at this code, I don't know what it means either.
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }

        // Delay until Joe Baseball goes back to original position
        yield return new WaitForSeconds(delayTime);

        // Joe Baseball's original position
        transform.rotation = Quaternion.Euler(new Vector3(0, 50, 0));
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // -90 is the rotation, 0.3f is the speed of the rotation
            StartCoroutine(RotateMe(Vector3.up * -90, 0.3f));


        }
    }
}
