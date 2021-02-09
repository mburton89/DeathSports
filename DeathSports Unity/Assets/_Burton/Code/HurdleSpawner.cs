using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurdleSpawner : MonoBehaviour
{
    [SerializeField] private HurdleObstacle _hurdlePrefab;
    [SerializeField] private HurdleObstacle _raptorPrefab;
    [SerializeField] private Transform _hurdleSpawnPoint1;
    [SerializeField] private Transform _hurdleSpawnPoint2;
    [SerializeField] private Transform _hurdleSpawnPoint3;
    [SerializeField] private Transform _raptorSpawnPoint;
    [SerializeField] private Transform _raptorSpawnPoint2;
    [SerializeField] private Transform _raptorSpawnPoint3;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _objectSpeed;

    private bool _canSpawnDouble;

    public float raptorSpeed;

    private void Start()
    {
        _canSpawnDouble = true;
        StartCoroutine(SpawnObject());
    }


    private IEnumerator SpawnObject()
    {
        int rand = Random.Range(0, 6);
        if (rand == 0) //spawn raptor
        {
            yield return new WaitForSeconds(_spawnRate / 3);
            int randS = Random.Range(0, 3);
            if (randS == 0)
            {
                HurdleObstacle raptor = Instantiate(_raptorPrefab, _raptorSpawnPoint.position, _raptorSpawnPoint.rotation, _raptorSpawnPoint) as HurdleObstacle;
                raptor.Init(1, _objectSpeed * raptorSpeed);
                HurdleObstacle raptor2 = Instantiate(_raptorPrefab, _raptorSpawnPoint2.position, _raptorSpawnPoint2.rotation, _raptorSpawnPoint2) as HurdleObstacle;
                raptor2.Init(1, _objectSpeed * raptorSpeed);
            }
            else if (randS == 1)
            {
                HurdleObstacle raptor = Instantiate(_raptorPrefab, _raptorSpawnPoint.position, _raptorSpawnPoint.rotation, _raptorSpawnPoint) as HurdleObstacle;
                raptor.Init(1, _objectSpeed * raptorSpeed);
                HurdleObstacle raptor2 = Instantiate(_raptorPrefab, _raptorSpawnPoint3.position, _raptorSpawnPoint3.rotation, _raptorSpawnPoint3) as HurdleObstacle;
                raptor2.Init(1, _objectSpeed * raptorSpeed);
            }
            else
            {
                HurdleObstacle raptor = Instantiate(_raptorPrefab, _raptorSpawnPoint3.position, _raptorSpawnPoint3.rotation, _raptorSpawnPoint3) as HurdleObstacle;
                raptor.Init(1, _objectSpeed * raptorSpeed);
                HurdleObstacle raptor2 = Instantiate(_raptorPrefab, _raptorSpawnPoint2.position, _raptorSpawnPoint2.rotation, _raptorSpawnPoint2) as HurdleObstacle;
                raptor2.Init(1, _objectSpeed * raptorSpeed);
            }
        }
        else if (rand == 1 || rand == 2) //spawn double hurdle
        {
            SpawnHurdlesRow();
            yield return new WaitForSeconds(_spawnRate / 2);
            SpawnHurdlesRow();
        }
        else //spawn one hurdle
        {
            SpawnHurdlesRow();
        }
        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnObject());
    }

    void SpawnHurdlesRow()
    {
        HurdleObstacle hurdle1 = Instantiate(_hurdlePrefab, _hurdleSpawnPoint1.position, _hurdleSpawnPoint1.rotation, _hurdleSpawnPoint1) as HurdleObstacle;
        hurdle1.Init(-1, _objectSpeed * 4);
        HurdleObstacle hurdle2 = Instantiate(_hurdlePrefab, _hurdleSpawnPoint2.position, _hurdleSpawnPoint2.rotation, _hurdleSpawnPoint2) as HurdleObstacle;
        hurdle2.Init(-1, _objectSpeed * 4);
        HurdleObstacle hurdle3 = Instantiate(_hurdlePrefab, _hurdleSpawnPoint3.position, _hurdleSpawnPoint3.rotation, _hurdleSpawnPoint3) as HurdleObstacle;
        hurdle3.Init(-1, _objectSpeed * 4);
    }
}
