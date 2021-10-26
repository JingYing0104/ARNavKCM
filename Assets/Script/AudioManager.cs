using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;

    public static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        instance = this;
    }
    public void AudioClick()
    {
        PlayAudio(0);
        
    }

    public void Audioreached()
    {
        PlayAudio(1);
    }

    public void PlayAudio(int index)
    {
        audioSource.clip = clips[index];
        audioSource.Play();
        
    }
}
