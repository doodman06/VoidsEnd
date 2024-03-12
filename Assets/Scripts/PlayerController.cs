using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehaviour))]
[RequireComponent(typeof(JumpBehaviour))]
[RequireComponent(typeof(SkillManager))]
[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerController : MonoBehaviour
{
    private MovementBehaviour movementBehaviour;
    private JumpBehaviour jumpBehaviour;
    private SkillManager skillManager;
    private PlayerBehaviour playerBehaviour;
    private void Awake()
    {
        movementBehaviour = GetComponent<MovementBehaviour>();
        jumpBehaviour = GetComponent<JumpBehaviour>();
        skillManager = GetComponent<SkillManager>();
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
            skillManager.UseActiveSkill();
        }
         
    }   
}
