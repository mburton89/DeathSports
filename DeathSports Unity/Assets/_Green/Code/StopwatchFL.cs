using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopwatchFL : MonoBehaviour
{
    public float timeStart;
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI startBtnText;

    public bool timerActive = false;

    // Use this for initialization
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        timerActive = true; //Starts Timer
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timeStart += Time.deltaTime; 
            textBox.text = timeStart.ToString("F2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")//other.collider.CompareTag("Player"))
        {
            timerActive = false; //Stops Timer on Collison
            Debug.Log("YOU WON!");
        }
    }


    /*public void timerButton()
    {
        timerActive = !timerActive;
        startBtnText.text = timerActive ? "Pause" : "Start";
    }*/
}