using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tntPrefab;
    [SerializeField] private int _numberOfTNTToSpawn;
    [SerializeField] private int _maxX;
    [SerializeField] private int _maxY;
    [SerializeField] private int _z; //Set this to whatever Z TNT in the scene is set to

    void Start()
    {
        for (int i = 0; i < _numberOfTNTToSpawn; i++)
        {
            float randX = Random.Range(-_maxX, _maxX);
            float randY = Random.Range(-_maxY, _maxY);
            Vector3 spawnPosition = new Vector3(randX, randY, _z);
            Instantiate(_tntPrefab, spawnPosition, transform.rotation, null);
        }
    }
}