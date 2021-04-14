using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource __AudioSource;
    public Toggle __EffectsToggle;
    private static BackgroundMusic __Instance = null;
    private bool __IsMute = false;
    public Toggle __MusicToggle;
    private float __MusicVolume = 1f;
    public Slider __MusicVolumeSLider;

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

    void Start()
    {
       
        __AudioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        __AudioSource.volume = __MusicVolume;
        __AudioSource.mute = __IsMute;
    }


}
