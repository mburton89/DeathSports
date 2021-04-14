using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdlesSoundManager : MonoBehaviour
{
    public static HurdlesSoundManager Instance;
    public AudioSource music;
    public AudioSource jump;
    public AudioSource splode;
    public AudioSource shortjump;
  
    public List<AudioSource> announcerDeathLines;
    public List<AudioSource> announcerRaptorLines;

    [HideInInspector] public bool canPlaySound;

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        if (Instance != null)
        {
            Instance.canPlaySound = true;
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            canPlaySound = true;
        }
    }

    public void PlayRandomAnnouncerDeathLine()
    {
        if (!canPlaySound) return;
        int rand = Random.Range(0, announcerDeathLines.Count);
        announcerDeathLines[rand].Play();
        canPlaySound = false;
    }
    public void PlayRandomRaptorDeathLine()
    {
        if (!canPlaySound) return;
        int rand = Random.Range(0, announcerRaptorLines.Count);
        announcerRaptorLines[rand].Play();
        canPlaySound = false;
    }
}
