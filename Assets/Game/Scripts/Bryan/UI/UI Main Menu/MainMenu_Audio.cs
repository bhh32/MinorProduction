using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Audio : MonoBehaviour 
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;

    void Start()
    {
        audio.Play();
        if (!audio.loop)
            audio.loop = true;
    }
}
