using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 3f;
    private Health playerHealth;
   // playerController Player; 

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        playerHealth = FindObjectOfType<Health>();
     //  Player = FindObjectOfType<playerController>();
    }

    private void Update()
    {
        CurrentHealth = playerHealth.health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

}
