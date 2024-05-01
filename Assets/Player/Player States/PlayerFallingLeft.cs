using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingLeft : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        player.animator.SetTrigger("Fall");
        player.GetComponent<JumpBehaviour>().ApplyFallingGravity();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerIdle();
        if (input == PlayerInput.MoveRight) return new PlayerFallingRight();
        if (input == PlayerInput.None) return new PlayerFalling();
        player.GetComponent<MovementBehaviour>().MoveLeft();
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
