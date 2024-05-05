using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerController : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    private Vector3 mousePos;
    private PlayerInput playerInput;

    private InputAction moveLeftAction;
    private InputAction moveRightAction;
    private InputAction jumpAction;
    private InputAction useSKillAction;
    private InputAction switchSkillAction;
    private InputAction mouseClickAction;
    private void Awake()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
        playerInput = GetComponent<PlayerInput>();
        LoadActions();
    }

    private void Start()
    {
        moveLeftAction = playerInput.actions.FindAction("MoveLeft");
        moveRightAction = playerInput.actions.FindAction("MoveRight");
        jumpAction = playerInput.actions.FindAction("Jump");
        useSKillAction = playerInput.actions.FindAction("UseSkill");
        switchSkillAction = playerInput.actions.FindAction("SwitchSkill");
        mouseClickAction = playerInput.actions.FindAction("MouseClick");
    }


    private void LoadActions()
    {
        playerInput.actions.LoadBindingOverridesFromJson(PlayerPrefs.GetString("ControlBindings"));
    }

    public void OnSwitchSkill(InputAction.CallbackContext context)
    {
        playerBehaviour.switchSkill();
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        OptionsMenuBehaviour.PauseGame();
    }

    public void OnUseSkill(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            playerBehaviour.setCurrentInput(PlayerInputEnum.Skill);
        }
    }

    private void Update()
    {
        if (moveRightAction.IsPressed())
        {
            playerBehaviour.setCurrentInput(PlayerInputEnum.MoveRight);
        }
        else if (moveLeftAction.IsPressed())
        {
            playerBehaviour.setCurrentInput(PlayerInputEnum.MoveLeft);
        }
        else
        {
            playerBehaviour.setCurrentInput(PlayerInputEnum.None);
        }

        if (jumpAction.IsPressed())
        {
            playerBehaviour.setCurrentInput(PlayerInputEnum.Jump);
        }

        

       

        

        //get cursor input
        if (mouseClickAction.IsPressed())
        {
            //get mouse position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerBehaviour.setMousePos(mousePos);
            playerBehaviour.setCurrentInput(PlayerInputEnum.MouseClick);
            

        }
         
    }   
}
