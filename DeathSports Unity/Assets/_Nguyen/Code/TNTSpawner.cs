using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tntPrefab;
    [SerializeField] private int _numberOfTNTToSpawn;
    [SerializeField] private float _maxX;
    [SerializeField] private float _y;
    [SerializeField] private float _maxZ; //Set this to whatever Z TNT in the scene is set to

    void Start()
    {
        for (int i = 0; i < _numberOfTNTToSpawn; i++)
        {
            float randX = Random.Range(-_maxX, _maxX); //change -maxX to zero
            float randZ = Random.Range(-_maxZ, _maxZ); //change -maxZ to zero
            Vector3 spawnPosition = new Vector3(randX, _y, randZ);
            GameObject tnt = Instantiate(_tntPrefab, spawnPosition, transform.rotation, null) as GameObject;

            float randRotation = Random.Range(0f, 360f);
            tnt.transform.eulerAngles = new Vector3(0, randRotation, 0);

        }
    }
}