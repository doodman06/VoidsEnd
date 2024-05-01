using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingLeft : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.Notify(EventEnum.Move);
        player.spriteRenderer.flipX = true;
        player.animator.SetTrigger("Run");
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (input == PlayerInput.Jump && player.jumpBehaviour.IsGrounded()) return new PlayerJumping();
        if (!player.jumpBehaviour.IsGrounded() && player.jumpBehaviour.IsFalling()) return new PlayerFalling();
        if (input == PlayerInput.MoveRight) return new PlayerMovingRight();
        if (input == PlayerInput.None) return new PlayerIdle();
        player.movementBehaviour.MoveLeft();
        player.animator.SetTrigger("Run");
        return null;

    }

    public void Exit(PlayerBehaviour player)
    {
        player.movementBehaviour.Stop();
        return;
    }
}
