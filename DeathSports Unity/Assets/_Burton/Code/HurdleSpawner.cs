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

    private bool _canSpawnDouble;

    private void Start()
    {
        _canSpawnDouble = true;
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        int rand = Random.Range(0, 6);
        if (rand == 0)
        {
            //spawn raptor
            yield return new WaitForSeconds(_spawnRate / 2);
            HurdleObstacle raptor = Instantiate(_raptorPrefab, _raptorSpawnPoint.position, _raptorSpawnPoint.rotation, _raptorSpawnPoint) as HurdleObstacle;
            raptor.Init(1, _objectSpeed * 6);
        }
        else if (rand == 1 || rand == 2)
        {
            //spawn double hurdle
            HurdleObstacle hurdle = Instantiate(_hurdlePrefab, _hurdleSpawnPoint.position, _hurdleSpawnPoint.rotation, _hurdleSpawnPoint) as HurdleObstacle;
            hurdle.Init(-1, _objectSpeed * 4);
            yield return new WaitForSeconds(_spawnRate / 2);
            HurdleObstacle hurdle2 = Instantiate(_hurdlePrefab, _hurdleSpawnPoint.position, _hurdleSpawnPoint.rotation, _hurdleSpawnPoint) as HurdleObstacle;
            hurdle2.Init(-1, _objectSpeed * 4);
        }
        else
        {
            //spawn one hurdle
            HurdleObstacle hurdle = Instantiate(_hurdlePrefab, _hurdleSpawnPoint.position, _hurdleSpawnPoint.rotation, _hurdleSpawnPoint) as HurdleObstacle;
            hurdle.Init(-1, _objectSpeed * 4);
        }
        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnObject());
    }
}
