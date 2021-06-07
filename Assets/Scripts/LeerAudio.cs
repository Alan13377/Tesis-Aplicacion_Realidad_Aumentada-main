using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeerAudio : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    void Start()
    {
        audio.clip = clip;
    }

    public void Reproducir()
    {
        audio.Play();
        
    }
}
