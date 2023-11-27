using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        if ( PlayerPrefs.HasKey("musicVolumen")) 
        {
            LoadVolumen();
        }
        else 
        {
            CambiarVolumen();
            CambiarSFX();
        }
    }

    public void CambiarVolumen()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolumen", volume);
    }

    public void CambiarSFX()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("Sounds", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolumen", volume);
    }

    private void LoadVolumen() 
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolumen");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolumen");

        CambiarSFX();
        CambiarVolumen();
    }
}
