using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    
    public void PlayMemoryMusic(AudioClip music)
    {
        musicSource.PlayOneShot(music);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
