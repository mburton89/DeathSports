﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeopleHit : MonoBehaviour
{
    public static int scoreValue = 0;
    TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "People Hit:  " + scoreValue;
    }
}
