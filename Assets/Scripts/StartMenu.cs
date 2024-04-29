using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject masterVolumeSlider;
    private Slider masterVolumeSliderComponent;

    private void Start()
    {
        masterVolumeSliderComponent = masterVolumeSlider.GetComponent<Slider>();
    }

    public void StartGame()
    {
        //start the game
        Debug.Log("Game started");
        SceneManager.LoadScene("Level1");
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
        masterVolumeSliderComponent.value = PlayerPrefs.GetInt("MasterVolume");
        
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
    }
}
