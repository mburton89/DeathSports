using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdToggle : MonoBehaviour
{
    public Sprite up;
    public Sprite down;
    public SpriteRenderer spriteRenderer;
    public float cheerSpeed;

    void Start()
    {
        StartCoroutine(Toggle());
    }

    private IEnumerator Toggle()
    {
        if (spriteRenderer.sprite == up)
        {
            spriteRenderer.sprite = down;
        }
        else
        {
            spriteRenderer.sprite = up;
        }

        yield return new WaitForSeconds(cheerSpeed);
        StartCoroutine(Toggle());
    }
}
