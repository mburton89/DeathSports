using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
    {
    public GameObject bomb;
    public float boom = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // OncollisionEnter, Bomb Range
    private void OnCollisionEnter(Collision collision)
    {
        if (bomb == enabled && collision.gameObject.tag == "Player")
        {
            print("BOOM!");
            Detonate();
        }
    }

    void Detonate()
    {
        Vector3 explosionPostion = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPostion, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(boom, explosionPostion, radius, upForce, ForceMode.Impulse);
            }
            
        }

    }
}
