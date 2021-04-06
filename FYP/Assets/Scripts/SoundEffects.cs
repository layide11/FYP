using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    private AudioSource __AudioSource;
    public static bool __IsMute = false;
    private static SoundEffects __Instance = null;

    void Start()
    {
        __AudioSource = GetComponent<AudioSource>();
    }


    public void MuteEffect(bool wantMusic)
    {
        __IsMute = !wantMusic;

    }

    void Awake()
    {
        if (__Instance == null)
        {
            __Instance = this;
        }
        else if (__Instance != this)
        {
            __IsMute = __Instance.GetIsMute();
            //__EffectsToggle.isOn = !__Instance.__IsMute;
            __Instance = this;
            return;
        }
    }

    public void PlayEffect()
    {
        if (!__IsMute)
        {
            __AudioSource.Play();
        }
    }


    public bool GetIsMute()
    {
        return __IsMute;
    }
}
