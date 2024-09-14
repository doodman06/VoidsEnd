using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    private static AudioSource bgmStatic;
    private static float masterVolume = 50;
    private static float sfxVolume = 100;
    private static float bgmVolume = 100;
    // Start is called before the first frame update


    void Start()
    {
        bgmStatic = bgm;
        masterVolume = PlayerPrefs.GetInt("MasterVolume", 50) / 100f;
        sfxVolume = PlayerPrefs.GetInt("SFXVolume", 100) / 100f;
        bgmVolume = PlayerPrefs.GetInt("BGMVolume", 100) / 100f;
        PlayBGM();
    }


    public static float getSfxVolume()
    {
        return sfxVolume * masterVolume;
    }

    public static float getBgmVolume()
    {
        return bgmVolume * masterVolume;
    }

    public static void UpdateVolume()
    {
        masterVolume = PlayerPrefs.GetInt("MasterVolume", 50) / 100f;
        sfxVolume = PlayerPrefs.GetInt("SFXVolume", 100) / 100f;
        bgmVolume = PlayerPrefs.GetInt("BGMVolume", 100) / 100f;
        UpdateBGMVolume();
    }

    private static void UpdateBGMVolume()
    {
        bgmStatic.volume = getBgmVolume();
    }

    public void PlayBGM()
    {
        bgm.volume = getBgmVolume();
        bgm.Play();
    }
    
}
