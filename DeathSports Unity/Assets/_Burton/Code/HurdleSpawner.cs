using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleSpawner : MonoBehaviour
{
    [SerializeField] private HurdleObstacle _hurdlePrefab;
    [SerializeField] private HurdleObstacle _raptorPrefab;
    [SerializeField] private Transform _hurdleSpawnPoint;
    [SerializeField] private Transform _raptorSpawnPoint;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _objectSpeed;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_spawnRate);

        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            HurdleObstacle raptor = Instantiate(_raptorPrefab, _raptorSpawnPoint.position, _raptorSpawnPoint.rotation, _raptorSpawnPoint) as HurdleObstacle;
            raptor.Init(1, _objectSpeed * 4);
        }
        else
        {
            HurdleObstacle hurdle = Instantiate(_hurdlePrefab, _hurdleSpawnPoint.position, _hurdleSpawnPoint.rotation, _hurdleSpawnPoint) as HurdleObstacle;
            hurdle.Init(-1, _objectSpeed * 4);
        }

        StartCoroutine(SpawnObject());
    }
}
