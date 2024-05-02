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

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (input == PlayerInput.MoveRight) return new PlayerFallingRight();
        if (input == PlayerInput.None) return new PlayerFalling();
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
