using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private IPlayerState currentState;

    private IPlayerState newState;

    private PlayerInput currentInput;

    private void Start()
    {
        currentState = new PlayerIdle();
        currentState.Enter(this);
    }
    public void setCurrentInput(PlayerInput input)
    {
        currentInput = input;
        UpdateState(currentInput);
    }

    /*private void Update()
    {
        UpdateState(currentInput);
    }*/

    public void UpdateState(PlayerInput input)
    {
        newState = currentState.Tick(this, currentInput);

        if(newState != null)
        {
            currentState.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }
        Debug.Log(currentState.GetType().Name);
    }
}
