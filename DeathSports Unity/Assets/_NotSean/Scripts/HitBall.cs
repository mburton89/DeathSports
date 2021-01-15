using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    public Rigidbody Ball;

    private void OnTriggerEnter(Collider other)
    {
        // Try to see if I can make this part random
        Ball.velocity = new Vector3(0, 15, 50);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
