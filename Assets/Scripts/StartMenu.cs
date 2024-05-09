using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject levelSelectorPanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private TextMeshProUGUI jumpButtonText;
    [SerializeField] private TextMeshProUGUI moveLeftButtonText;
    [SerializeField] private TextMeshProUGUI moveRightButtonText;
    [SerializeField] private TextMeshProUGUI skillButtonText;
    [SerializeField] private TextMeshProUGUI switchSkillButtonText;
    [SerializeField] private TextMeshProUGUI escapeButtonText;
    [SerializeField] private TextMeshProUGUI interactButtonText;
    [SerializeField] private GameObject masterVolumeSlider;
    [SerializeField] private GameObject sfxVolumeSlider;
    [SerializeField] private GameObject bgmVolumeSlider;
    private Slider masterVolumeSliderComponent;
    private Slider sfxVolumeSliderComponent;
    private Slider bgmVolumeSliderComponent;
    private PlayerInput playerInput;

    private InputAction moveLeftAction;
    private InputAction moveRightAction;
    private InputAction jumpAction;
    private InputAction useSKillAction;
    private InputAction switchSkillAction;
    private InputAction mouseClickAction;
    private InputAction escapeAction;
    private InputAction interactAction;

    private void Start()
    {
        masterVolumeSliderComponent = masterVolumeSlider.GetComponent<Slider>();
        sfxVolumeSliderComponent = sfxVolumeSlider.GetComponent<Slider>();
        bgmVolumeSliderComponent = bgmVolumeSlider.GetComponent<Slider>();
        playerInput = GetComponent<PlayerInput>();
        moveLeftAction = playerInput.actions.FindAction("MoveLeft");
        moveRightAction = playerInput.actions.FindAction("MoveRight");
        jumpAction = playerInput.actions.FindAction("Jump");
        useSKillAction = playerInput.actions.FindAction("UseSkill");
        switchSkillAction = playerInput.actions.FindAction("SwitchSkill");
        mouseClickAction = playerInput.actions.FindAction("MouseClick");
        escapeAction = playerInput.actions.FindAction("Escape");
        interactAction = playerInput.actions.FindAction("Interact");
        LoadActions();
    
        DisableAllActions();
        UpdateControlsUI();

    }

    public void EnableAllActions()
    {
        moveLeftAction.Enable();
        moveRightAction.Enable();
        jumpAction.Enable();
        useSKillAction.Enable();
        switchSkillAction.Enable();
        mouseClickAction.Enable();
        escapeAction.Enable();
        interactAction.Enable();
    }

    public void DisableAllActions()
    {
        moveLeftAction.Disable();
        moveRightAction.Disable();
        jumpAction.Disable();
        useSKillAction.Disable();
        switchSkillAction.Disable();
        mouseClickAction.Disable();
        escapeAction.Disable();
        interactAction.Disable();
    }

    public void StartGame()
    {
        //start the game
        EnableAllActions();
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
        EnableAllActions();
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

    public void OpenControls()
    {
        //open controls menu
        Debug.Log("Controls menu opened");
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        //close controls menu
        Debug.Log("Controls menu closed");
        controlsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        //open credits menu
        Debug.Log("Credits menu opened");
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        //close credits menu
        Debug.Log("Credits menu closed");
        creditsPanel.SetActive(false);
    }

    public void RemapButtonClicked(string currentInput)
    {
        var actionToRebind = jumpAction;
        switch(currentInput)
        {
            case "Jump":
                actionToRebind = jumpAction;
                break;
            case "MoveLeft":
                actionToRebind = moveLeftAction;
                break;
            case "MoveRight":
                actionToRebind = moveRightAction;
                break;
            case "Skill":
                actionToRebind = useSKillAction;
                break;
            case "SwitchSkill":
                actionToRebind = switchSkillAction;
                break;
            case "Escape":
                actionToRebind = escapeAction;
                break;
            case "Interact":
                actionToRebind = interactAction;
                break;
        }

        var rebindOperation = actionToRebind.PerformInteractiveRebinding()
                    // To avoid accidental input from mouse motion
                    .WithControlsExcluding("Mouse")
                    .OnMatchWaitForAnother(0.1f)
                    .Start();
        rebindOperation.OnComplete(operation =>
        {
            UpdateControlsUI();
            SaveActions();
        });
    }

    public void UpdateControlsUI()
    {
        jumpButtonText.text = jumpAction.GetBindingDisplayString(0);
        moveLeftButtonText.text = moveLeftAction.GetBindingDisplayString(0);
        moveRightButtonText.text = moveRightAction.GetBindingDisplayString(0);
        skillButtonText.text = useSKillAction.GetBindingDisplayString(0);
        skillButtonText.text = skillButtonText.text.Split(' ')[1];
        switchSkillButtonText.text = switchSkillAction.GetBindingDisplayString(0);
        escapeButtonText.text = escapeAction.GetBindingDisplayString(0);
        interactButtonText.text = interactAction.GetBindingDisplayString(0);

        
    }
    public void SaveActions()
    {
        var rebinds = playerInput.actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("ControlBindings", rebinds);
    }

    public void LoadActions()
    {
        playerInput.actions.LoadBindingOverridesFromJson(PlayerPrefs.GetString("ControlBindings"));
    }

    public void ResetControls()
    {
        PlayerPrefs.DeleteKey("ControlBindings");
        LoadActions();
        UpdateControlsUI();
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
