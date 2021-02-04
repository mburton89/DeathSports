using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = .1f;
    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        _rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        _rend.material.SetTextureOffset("_BumpMap", new Vector2(offset, 0));
    }
}
