using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTScenarioSpawner : MonoBehaviour
{
    public List<GameObject> scenarios;

    void Start()
    {
        scenarios[Random.Range(0, scenarios.Count)].SetActive(true);
    }
}
