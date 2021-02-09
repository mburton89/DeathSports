using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdlesSoundManager : MonoBehaviour
{
    public static HurdlesSoundManager Instance;
    public AudioSource music;
    public AudioSource jump;
    public AudioSource splode;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
