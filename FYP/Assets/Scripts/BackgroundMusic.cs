using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private bool _IsMuted;
    void Start()
    {
        _IsMuted = false;
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void MuteMusic()
    {
        _IsMuted = !_IsMuted;
        AudioListener.pause = _IsMuted;
    }

}
