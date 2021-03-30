using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private AudioSource __AudioSource;
    private bool __IsMute = false;

    void Start()
    {
        __AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (__IsMute)
        {
            __AudioSource.volume = 0f;
        }
        else
        {
            __AudioSource.volume = 1f;
        }
      
    }

    public void MuteEffect(bool wantMusic)
    {
        __IsMute = !wantMusic;

    }
}
