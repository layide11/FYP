using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    private bool __IsMute = false;
    private float __MusicVolume = 1f;
    private AudioSource __AudioSource;
    private static BackgroundMusic __Instance = null;

    public Slider __MusicVolumeSLider;
    public Toggle __MusicToggle;
    public Toggle __EffectsToggle;
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
        if (__Instance == null)
        {
            __Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (__Instance != this)
        {
            Destroy(__Instance.gameObject);
            __MusicVolumeSLider.value = __Instance.__MusicVolume;
            __EffectsToggle.isOn = !FindObjectOfType<SoundEffects>().GetIsMute();
            __MusicToggle.isOn = !__Instance.__IsMute;
            __Instance = this;
            DontDestroyOnLoad(__Instance.gameObject);
            return;
        }
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
