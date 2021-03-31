using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimSoundManager : MonoBehaviour
{
    public static HurdlesSoundManager Instance;
    public AudioSource music;



    public List<AudioSource> announcerSwimDeathLines;
   

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
        int rand = Random.Range(0, announcerSwimDeathLines.Count);
        announcerSwimDeathLines[rand].Play();
        //replace  announcerDeathLines with annoucerRaptorDeathLines
    }
    
}
