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

    public void PlayRandomAnnouncerDeathLine()
    {
        int rand = Random.Range(0, announcerDeathLines.Count);
        announcerDeathLines[rand].Play();
        //replace  announcerDeathLines with annoucerRaptorDeathLines
    }
    public void PlayRandomRaptorDeathLine()
    {
        int rand = Random.Range(0, announcerRaptorLines.Count);
        announcerRaptorLines[rand].Play();
        //replace  announcerDeathLines with annoucerRaptorDeathLines
    }
}
