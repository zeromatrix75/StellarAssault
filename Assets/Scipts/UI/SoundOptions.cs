using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        if (PlayerPrefs.GetInt("SetDefaultVolume") != 1)
        {
            PlayerPrefs.SetInt("SetDefaultVolume", 1);

            masterSlider.value = 0.5f;
            PlayerPrefs.SetFloat("master volume", 0.5f);

            musicSlider.value = 0.5f;
            PlayerPrefs.SetFloat("music volume", 0.5f);

            sfxSlider.value = 0.5f;
            PlayerPrefs.SetFloat("sfx volume", 0.5f);
        }
        else
        {
            masterSlider.value = PlayerPrefs.GetFloat("master volume");
            sfxSlider.value = PlayerPrefs.GetFloat("sfx volume");
            musicSlider.value = PlayerPrefs.GetFloat("music volume");
        }
    }

    void SetVolume(string name, float value)
    {
        // Convert Volume slider from 0-1 to Decibels(-80 to 20)Range 
        float volume = Mathf.Log10(value) * 20;
        if (value == 0)
        {
            volume = -80;
        }

        audioMixer.SetFloat(name, volume);
    }

    public void SetMasterVolume()
    {
        SetVolume("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("master volume", masterSlider.value);
    }

    public void SetMusicVolume()
    {
        SetVolume("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("music volume", musicSlider.value);
    }

    public void SetSFXVolume()
    {
        SetVolume("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("sfx volume", sfxSlider.value);
    }
}
