using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    #region Singleton

    public static SoundManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    [Header("Audio Sources")]
    public AudioSource indyAudioSource;
    public AudioSource bgAudioSource;
    public AudioSource successAudioSource;

    [Header("Audio Clips")]
    public AudioClip whipSound;
    public AudioClip successMusic;
    public AudioClip backgroundMusic;

    public void PlayIndyAudio(AudioClip clip)
    {
        indyAudioSource.PlayOneShot(clip);
    }

    public void StopIndyAudio()
    {
        indyAudioSource.Stop();
    }

    public void PlayBackgroundAudio(AudioClip clip)
    {
        bgAudioSource.PlayOneShot(clip);
    }

    public void StopBackgroundAudio()
    {
        bgAudioSource.Stop();
    }

    public void PlaySuccessAudio(AudioClip clip)
    {
        successAudioSource.PlayOneShot(clip);
    }

    public void StopSuccessAudio()
    {
        successAudioSource.Stop();
    }
}
