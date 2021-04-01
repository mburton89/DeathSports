using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallsPitchedCounter : MonoBehaviour
{
    public static int scoreValue1 = 0;
    TextMeshProUGUI score1;

    // Start is called before the first frame update
    void Start()
    {
        score1 = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score1.text = "Pitches Thrown:  " + scoreValue1;
    }
}