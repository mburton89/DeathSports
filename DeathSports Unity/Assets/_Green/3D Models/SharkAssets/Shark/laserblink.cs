using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserblink : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject laser;
    void Start()
    {
        StartCoroutine(ToggleLaser());
    }

    IEnumerator ToggleLaser()
    {
        laser.SetActive(false);
        yield return new WaitForSeconds(1);
        laser.SetActive(true);
        yield return new WaitForSeconds(1);
        StartCoroutine(ToggleLaser());
    }
}

// Update is called once per frame
    /*void Update()
    {
        
    }*/

