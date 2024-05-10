using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class optionHandler : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle fullscreenToggle;
    public GameObject optionsPanel;  
    void Start()
    {
        // Initialize with current settings
        masterVolumeSlider.value = AudioListener.volume;
        fullscreenToggle.isOn = Screen.fullScreen;

        
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        
        // MusicManager.SetVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        
        // SFXManager.SetVolume(volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ToggleOptionsPanel(bool isOpen)
    {
        optionsPanel.SetActive(isOpen);
    }
}
