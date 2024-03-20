using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.GetComponent<JumpBehaviour>().Jump();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerIdle();
        if (input == PlayerInput.MoveRight) return new PlayerJumpingRight();
        if (input == PlayerInput.MoveLeft) return new PlayerJumpingLeft();
        
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        return;
    }
}
