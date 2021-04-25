using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballSoundManager : MonoBehaviour
{
    public static BaseballSoundManager Instance;
    public AudioSource music;
    public AudioSource swing;
    public AudioSource pitch;
    public AudioSource baseballhit;
    public AudioSource splode;
    public AudioSource Billboardsplode;

    public List<AudioSource> announcerBaseballDeathLines;

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

    public void PlayRandomAnnouncerBaseballDeathLine()
    {
        int rand = Random.Range(0, announcerBaseballDeathLines.Count);
        announcerBaseballDeathLines[rand].Play();
    }
}
