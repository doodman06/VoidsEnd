using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingLeft : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.spriteRenderer.flipX = true;
        player.animator.SetTrigger(AnimationStruct.Fall);
        player.jumpBehaviour.ApplyFallingGravity();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {
        if (input == PlayerInputEnum.Skill && player.IsActiveSkillUsable()) return new PlayerUsingSkill();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (input == PlayerInputEnum.MoveRight) return new PlayerFallingRight();
        if (input == PlayerInputEnum.None) return new PlayerFalling();
        player.movementBehaviour.MoveLeft();
        player.animator.SetTrigger(AnimationStruct.Fall);
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        player.movementBehaviour.Stop();
        player.jumpBehaviour.ResetGravity();
        return;
    }
}
