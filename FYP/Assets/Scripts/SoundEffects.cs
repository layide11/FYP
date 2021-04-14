using UnityEngine;


public class SoundEffects : MonoBehaviour
{
    private AudioSource __AudioSource;
    private static SoundEffects __Instance = null;
    public static bool __IsMute = false;

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

    public bool GetIsMute()
    {
        return __IsMute;
    }

    public void MuteEffect(bool wantMusic)
    {
        __IsMute = !wantMusic;

    }

    public void PlayEffect()
    {
        if (!__IsMute)
        {
            __AudioSource.Play();
        }
    }

    void Start()
    {
        __AudioSource = GetComponent<AudioSource>();
    }

}
