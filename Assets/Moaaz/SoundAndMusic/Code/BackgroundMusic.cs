using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource Src;
    public AudioClip Music;

    private void Start()
    {
        Src.clip = Music;
        Src.Play();
    }
}

