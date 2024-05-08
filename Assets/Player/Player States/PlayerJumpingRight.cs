using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingRight : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.spriteRenderer.flipX = false;
        player.animator.SetTrigger(AnimationStruct.Jump);
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {
        if (input == PlayerInputEnum.Skill && player.IsActiveSkillUsable()) return new PlayerUsingSkill();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (player.jumpBehaviour.IsFalling()) return new PlayerFalling();
        if(input == PlayerInputEnum.MoveLeft) return new PlayerJumpingLeft();
        if(input == PlayerInputEnum.None) return new PlayerJumpNoDirection();
        player.movementBehaviour.MoveRight();
        player.animator.SetTrigger(AnimationStruct.Jump);
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        player.movementBehaviour.Stop();
        return;
    }
}
