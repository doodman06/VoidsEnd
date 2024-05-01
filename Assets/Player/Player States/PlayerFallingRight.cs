using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingRight : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.GetComponent<SpriteRenderer>().flipX = false;
        player.animator.SetTrigger("Fall");
        player.GetComponent<JumpBehaviour>().ApplyFallingGravity();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerIdle();
        if (input == PlayerInput.MoveLeft) return new PlayerFallingLeft();
        if (input == PlayerInput.None) return new PlayerFalling();
        player.GetComponent<MovementBehaviour>().MoveRight();
        player.animator.SetTrigger("Fall");
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        player.GetComponent<MovementBehaviour>().Stop();
        player.GetComponent<JumpBehaviour>().ResetGravity();
        return;
    }
}
