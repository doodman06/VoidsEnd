using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehaviour))]
[RequireComponent(typeof(JumpBehaviour))]
[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerController : MonoBehaviour
{
    private MovementBehaviour movementBehaviour;
    private JumpBehaviour jumpBehaviour;
    private PlayerBehaviour playerBehaviour;
    private Vector3 mousePos;
    private void Awake()
    {
        movementBehaviour = GetComponent<MovementBehaviour>();
        jumpBehaviour = GetComponent<JumpBehaviour>();
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
