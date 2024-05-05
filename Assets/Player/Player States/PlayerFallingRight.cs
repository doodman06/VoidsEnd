using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingRight : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.spriteRenderer.flipX = false;
        player.animator.SetTrigger(AnimationStruct.Fall);
        player.jumpBehaviour.ApplyFallingGravity();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {
        if (input == PlayerInputEnum.Skill) return player.getActiveSkillState();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (input == PlayerInputEnum.MoveLeft) return new PlayerFallingLeft();
        if (input == PlayerInputEnum.None) return new PlayerFalling();
        player.movementBehaviour.MoveRight();
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
