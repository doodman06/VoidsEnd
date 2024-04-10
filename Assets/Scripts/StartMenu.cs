using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void startGame()
    {
        //start the game
        Debug.Log("Game started");
        SceneManager.LoadScene("Level1");
    }
}
