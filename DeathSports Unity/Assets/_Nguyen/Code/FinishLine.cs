using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour

{
    public GameObject Goal;
    public GameManager gameManager;
    public Swimmer swimmer;
    void OnTriggerEnter(Collider collider)
    {
        gameManager.CompleteLevel();
        swimmer.enabled = false;

    }
}
