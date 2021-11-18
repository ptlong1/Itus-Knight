using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public ParticleSystem deadFX;
    public AudioClip dieSound;
    AudioSource audioSource;
    void Start()
    {

        GetComponent<Health>().OnDeathTrigger += OnDeathTrigger;       
        audioSource = GetComponent<AudioSource>(); 
    }

    void OnDeathTrigger(){
        deadFX.Play();
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAim>().enabled = false;
        audioSource.clip = dieSound;
        audioSource.Play();
    }
}
