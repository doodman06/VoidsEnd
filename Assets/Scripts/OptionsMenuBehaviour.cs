using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    private static GameObject optionsPanelStatic;
    private static float prevTimeScale;
    private static bool isPaused = false;


    private void Awake()
    {
        optionsPanelStatic = optionsPanel;
    }

    public static void PauseGame()
    {   if (isPaused) return;
        prevTimeScale = Time.timeScale;
        isPaused = true;
        optionsPanelStatic.SetActive(true);

        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        if (!isPaused) return;
        optionsPanelStatic.SetActive(false);
        Time.timeScale = prevTimeScale;
        isPaused = false;
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1;
        ResetPauseState();
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }

    public void ResetPauseState()
    {
        isPaused = false;  
    }


}
