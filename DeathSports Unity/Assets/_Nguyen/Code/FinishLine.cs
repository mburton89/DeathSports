using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour

{
    public GameObject Goal;
    public SwimGameManager GameManager;
    public Swimmer swimmer;
    public GameObject completeLevel;
    void OnTriggerEnter(Collider collider)
    {
        GameManager.CompleteLevel();
        swimmer.enabled = false;

    }
}
