using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject levelSelectorPanel;
    [SerializeField] private GameObject masterVolumeSlider;
    [SerializeField] private GameObject sfxVolumeSlider;
    [SerializeField] private GameObject bgmVolumeSlider;
    private Slider masterVolumeSliderComponent;
    private Slider sfxVolumeSliderComponent;
    private Slider bgmVolumeSliderComponent;

    private void Start()
    {
        masterVolumeSliderComponent = masterVolumeSlider.GetComponent<Slider>();
        sfxVolumeSliderComponent = sfxVolumeSlider.GetComponent<Slider>();
        bgmVolumeSliderComponent = bgmVolumeSlider.GetComponent<Slider>();
    }

    public void StartGame()
    {
        //start the game
        Debug.Log("Game started");
        SceneManager.LoadScene("Level1");
    }

    public void OpenLevelSelector()
    {
        //open level selector
        Debug.Log("Level selector opened");
        levelSelectorPanel.SetActive(true);
    }

    public void CloseLevelSelector()
    {
        //close level selector
        Debug.Log("Level selector closed");
        levelSelectorPanel.SetActive(false);
    }

    public void LoadLevel(string levelName)
    {
        //load the level
        Debug.Log("Level loaded: " + levelName);
        SceneManager.LoadScene(levelName);
    }
    public void QuitGame()
    {
        //quit the game
        Debug.Log("Game quit");
        Application.Quit();
    }

    public void OpenOptions()
    {
        //open options menu
        Debug.Log("Options menu opened");
        optionsPanel.SetActive(true);
        //set master volume slider to current volume
        UpdateVolumeSliders();
        
    }

    public void UpdateVolumeSliders()
    {
        //update volume sliders
        masterVolumeSliderComponent.value = PlayerPrefs.GetInt("MasterVolume");
        sfxVolumeSliderComponent.value = PlayerPrefs.GetInt("SFXVolume");
        bgmVolumeSliderComponent.value = PlayerPrefs.GetInt("BGMVolume");
    }

    public void CloseOptions()
    {
        //close options menu
        Debug.Log("Options menu closed");
        optionsPanel.SetActive(false);
    }

    public void MasterVolumeUpdate(float val)
    {
        //update master volume
        Debug.Log("Master volume updated to: " + val);
        PlayerPrefs.SetInt("MasterVolume", (int) val);
        SoundManagerBehaviour.UpdateVolume();
    }

    public void SFXVolumeUpdate(float val)
    {
        //update sfx volume
        Debug.Log("SFX volume updated to: " + val);
        PlayerPrefs.SetInt("SFXVolume", (int) val);
        SoundManagerBehaviour.UpdateVolume();
    }

    public void BGMVolumeUpdate(float val)
    {
        //update bgm volume
        Debug.Log("BGM volume updated to: " + val);
        PlayerPrefs.SetInt("BGMVolume", (int) val);
        SoundManagerBehaviour.UpdateVolume();
    }



}
