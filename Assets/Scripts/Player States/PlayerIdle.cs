using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if(input == PlayerInput.Jump && player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerJumping();
        if(!player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerJumpNoDirection();
        if (input == PlayerInput.MoveRight) return new PlayerMovingRight();
        if (input == PlayerInput.MoveLeft) return new PlayerMovingLeft();
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        return;
    }

}
