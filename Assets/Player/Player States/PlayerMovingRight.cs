using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingRight : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.GetComponent<SpriteRenderer>().flipX = false;
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (input == PlayerInput.Jump && player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerJumping();
        if(input == PlayerInput.MoveLeft) return new PlayerMovingLeft();
        if(input == PlayerInput.None) return new PlayerIdle();
        player.GetComponent<MovementBehaviour>().MoveRight();
        return null;

    }

    public void Exit(PlayerBehaviour player)
    {
        player.GetComponent<MovementBehaviour>().Stop();
        return;
    }
}
