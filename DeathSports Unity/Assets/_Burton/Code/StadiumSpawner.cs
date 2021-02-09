using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumSpawner : MonoBehaviour
{
    [SerializeField] private MoveHoriztontally _stadiumSlicePrefab;
    [SerializeField] private Transform _stadiumSliceSpawnPoint;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _objectSpeed;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        MoveHoriztontally stadiumSlice = Instantiate(_stadiumSlicePrefab, _stadiumSliceSpawnPoint.position, _stadiumSliceSpawnPoint.rotation, null) as MoveHoriztontally;
        stadiumSlice.Init(-1, _objectSpeed);
        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnObject());
    }
}
