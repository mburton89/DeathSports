using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject BaseballPrefab;
    public float SpawnTime = 3f;

    private void Start()
    {
        StartCoroutine(BaseballGenerator());
    }

    void SpawnBaseBall()
    {
        GameObject gameRef = Instantiate(BaseballPrefab) as GameObject;
        gameRef.name = "Ball";

        gameRef.transform.position = new Vector3(258.73f, 1.8f, 286.143f);
    }

    IEnumerator BaseballGenerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            SpawnBaseBall();
        }
    }
}
