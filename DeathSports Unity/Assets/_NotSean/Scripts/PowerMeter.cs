using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerMeter : MonoBehaviour
{
    [SerializeField]
    private Image imagePowerUp;

    private bool isPowerUp = false;
    private bool isDirectionUp = true;
    private float amountPower = 0.0f;
    private float powerSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            PowerActive();
        }

        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Delay());
        }
    }

    void PowerActive()
    {
        if (isDirectionUp)
        {
            amountPower += Time.deltaTime * powerSpeed;
            if(amountPower > 100)
            {
                isDirectionUp = false;
                amountPower = 100.0f;
            }
        }

        else
        {
            amountPower -= Time.deltaTime * powerSpeed;
            if (amountPower < 100)
            {
                isDirectionUp = true;
                amountPower = 0.0f;
            }
        }

        imagePowerUp.fillAmount = (1f - 0f) * amountPower / 100.0f + 0f;
    }

    public void StartPowerUp()  
    {
        isPowerUp = true;
        amountPower = 0.0f;
        isDirectionUp = true;
    }

    public void EndPowerUp()
    {
        isPowerUp = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.1f);
        imagePowerUp.fillAmount = 0;
        amountPower = 0.0f;
    }
}
