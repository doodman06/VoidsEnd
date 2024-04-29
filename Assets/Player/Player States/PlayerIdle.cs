using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.animator.SetTrigger("Idle");
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if(input == PlayerInput.Skill) return player.getActiveSkillState();
        if(input == PlayerInput.Jump && player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerJumping();
        if(!player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerJumpNoDirection();
        if (input == PlayerInput.MoveRight) return new PlayerMovingRight();
        if (input == PlayerInput.MoveLeft) return new PlayerMovingLeft();
        player.animator.SetTrigger("Idle");
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        return;
    }

}
