using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingRight : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.Notify(EventEnum.Move);
        player.spriteRenderer.flipX = false;
        player.animator.SetTrigger(AnimationStruct.Run);
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (input == PlayerInput.Jump && player.jumpBehaviour.IsGrounded()) return new PlayerJumping();
        if (!player.jumpBehaviour.IsGrounded() && player.jumpBehaviour.IsFalling()) return new PlayerFalling();
        if (input == PlayerInput.MoveLeft) return new PlayerMovingLeft();
        if(input == PlayerInput.None) return new PlayerIdle();
        player.movementBehaviour.MoveRight();
        player.animator.SetTrigger(AnimationStruct.Run);
        return null;

    }

    public void Exit(PlayerBehaviour player)
    {
        player.movementBehaviour.Stop();
        return;
    }
}
