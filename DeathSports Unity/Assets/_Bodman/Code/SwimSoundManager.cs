using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimSoundManager : MonoBehaviour
{
    public static SwimSoundManager Instance;
    public AudioSource music;
    public AudioSource Swim;
    public AudioSource splode;


    public List<AudioSource> announcerSwimDeathLines;
 

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayRandomAnnouncerSwimDeathLine()
    {
        int rand = Random.Range(0, announcerSwimDeathLines.Count);
        announcerSwimDeathLines[rand].Play();
        
    }
   
}
