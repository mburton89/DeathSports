using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 3f;
   // playerController Player; 

    private void Start()
    {
       HealthBar = GetComponent<Image>();
     //  Player = FindObjectOfType<playerController>();
    }

    private void Update()
    {
       CurrentHealth = Health;
       HealthBar.fillAmount = CurrentHealth / MaxHealth; 
    }





}
