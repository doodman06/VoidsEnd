using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingLeft : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        player.animator.SetTrigger("Jump");
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerIdle();
        if (player.GetComponent<JumpBehaviour>().IsFalling()) return new PlayerFalling();
        if (input == PlayerInput.MoveRight) return new PlayerJumpingRight(); 
        if(input ==  PlayerInput.None) return new PlayerJumpNoDirection();
        player.GetComponent<MovementBehaviour>().MoveLeft();
        player.animator.SetTrigger("Jump");
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        player.GetComponent<MovementBehaviour>().Stop();
        return;
    }
}
