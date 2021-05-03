using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bloodboi : MonoBehaviour
{
    public GameObject blood;
    public GameObject Player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TallBean")//other.collider.CompareTag("Player"))
            {
            Blood();
        }
    }
    void Blood()
    {
        GameObject blood2 = Instantiate(blood, Player.transform.position, Quaternion.identity) as GameObject;
        Player.GetComponent<CharacterController>().enabled = false; //Stops Bean Movement but not camera 
        //Vector3 position = default;
        Debug.Log("BLOOD");
        //GameObject blood2 = Instantiate(blood, position, Quaternion.identity);
        blood2.GetComponent<ParticleSystem>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Restarts Scene but it's instant
    }

    private GameObject Instantiate(GameObject blood, GameObject player, Quaternion identity)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
