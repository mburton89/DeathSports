﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MenteBacata.ScivoloCharacterController;
using MenteBacata.ScivoloCharacterControllerDemo;

public class HurdleObstacle : MonoBehaviour
{
    private Vector3 _movementDirection;
    private float _movementSpeed;
    [SerializeField] private bool _isRaptor;

    public void Init(int xDirection, float movementSpeed)
    {
        _movementDirection = new Vector3 (xDirection, 0, 0);
        _movementSpeed = movementSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
            Destroy(gameObject);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.gameObject.GetComponent<GroundDetector>().enabled = false;
            collision.gameObject.GetComponent<CharacterMover>().enabled = false;
            collision.gameObject.GetComponent<SimpleCharacterController>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000f, transform.position, 50f);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 400f);
            HurdlesGameManager.Instance.Restart();
        }

        if (collision.gameObject.GetComponent<HurdleObstacle>() && !_isRaptor)
        {
            Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate((_movementDirection * _movementSpeed) * Time.deltaTime);
        if (transform.position.x > 15 || transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
