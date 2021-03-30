using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private bool __IsMute = false;
    private float __MusicVolume = 1f;
    private AudioSource __AudioSource;

    void Start()
    {
        __AudioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        __AudioSource.volume = __MusicVolume;
        __AudioSource.mute = __IsMute;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void MuteMusic(bool wantMusic)
    {
        __IsMute = !wantMusic;
       
    }

 
    public void SetVolume(float volume)
    {
        __MusicVolume = volume;
    }
}
