using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerController : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    private Vector3 mousePos;
    private void Awake()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerBehaviour.setCurrentInput(PlayerInput.MoveRight);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerBehaviour.setCurrentInput(PlayerInput.MoveLeft);
        }
        else
        {
            playerBehaviour.setCurrentInput(PlayerInput.None);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBehaviour.setCurrentInput(PlayerInput.Jump);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerBehaviour.setCurrentInput(PlayerInput.Skill);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerBehaviour.switchSkill();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsMenuBehaviour.PauseGame();
        }

        //get cursor input
        if (Input.GetMouseButtonDown(0))
        {
            //get mouse position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerBehaviour.setMousePos(mousePos);
            playerBehaviour.setCurrentInput(PlayerInput.MouseClick);
            

        }
         
    }   
}
