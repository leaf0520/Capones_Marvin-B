using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController Instance;

    [Header("BGMS")]
    public AudioSource BgmAudioSource;
    public AudioClip MainMenuBgm;
    public AudioClip Level1Bgm;

    [Header("SFXS")]
    public AudioSource SfxAudioSource;
    public AudioClip ButtonsSFX;
    public AudioClip ShootingSFX;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // BgmAudioSource.clip = MainMenuBgm;
        // BgmAudioSource.Play();
        PlayBGM(MainMenuBgm);
    }

    public void PlayBGM(AudioClip bgmToPlay)
    {
        BgmAudioSource.clip = bgmToPlay;
        BgmAudioSource.Play();
    }

    public void PlaySFX(AudioClip sfxToPlay)
    {
        SfxAudioSource.PlayOneShot(sfxToPlay);
    }

    public float LoadBGMVolume()
    {
        if (PlayerPrefs.HasKey("BgmVolume"))
        {
            BgmAudioSource.volume = PlayerPrefs.GetFloat("BgmVolume");
            return PlayerPrefs.GetFloat("BgmVolume");
        }
        else
        {
            BgmAudioSource.volume = 1;
            return 1;
        }
    }

    public void SaveBgmVolume(float value)
    {
        PlayerPrefs.SetFloat("BgmVolume", value);
    }
}
