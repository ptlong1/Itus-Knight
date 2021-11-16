using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHitController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip hitSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(AudioClip clip){
        if (audioSource.isPlaying){
            audioSource.Stop();
        }
        audioSource.clip = clip;
        audioSource.Play();
    }
}
