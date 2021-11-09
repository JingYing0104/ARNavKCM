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

    public void AudioGoStraight()
    {
        PlayAudio(2);
    }

    public void AudioTurnLeft()
    {
        PlayAudio(3);
    }

    public void AudioTurnRight()
    {
        PlayAudio(4);
    }

    public void AudioYouAreReached()
    {
        PlayAudio(5);
    }

    public void PlayAudio(int index)
    {
        audioSource.clip = clips[index];
        audioSource.PlayOneShot(audioSource.clip);
        
    }
}
