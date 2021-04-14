using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwimHUD : MonoBehaviour
{
    public static SwimHUD Instance;
    public float startXPos; //32.5
    public float endXPos; //-21
    public Image fill;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateFillBar(float swimXposition)
    {
        fill.fillAmount = (startXPos - swimXposition) / 32;
    }
}
