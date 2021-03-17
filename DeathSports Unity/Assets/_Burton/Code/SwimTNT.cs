using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwimTNT : MonoBehaviour
{
    //TODO Make TNT Bob up and Down like its floating in water

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<SuperSmartCamera>().enabled = false;
            Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
            Destroy(gameObject);
            Rigidbody swimmerRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            swimmerRigidBody.isKinematic = false;
            swimmerRigidBody.drag = swimmerRigidBody.drag / 4;
            swimmerRigidBody.useGravity = true;
            swimmerRigidBody.AddExplosionForce(1500f, transform.position, 50f);
            swimmerRigidBody.AddForce(Vector3.up * 400f);
            collision.gameObject.GetComponent<Swimmer>().enabled = false;
            //TODO Play Explosion Sound
            //TODO Restart the scene after 2 seconds
            SwimGameManager.Instance.Restart();

        }
    }
}

