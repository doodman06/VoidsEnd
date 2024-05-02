using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingLeft : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.spriteRenderer.flipX = true;
        player.animator.SetTrigger(AnimationStruct.Jump);
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (player.jumpBehaviour.IsFalling()) return new PlayerFalling();
        if (input == PlayerInput.MoveRight) return new PlayerJumpingRight(); 
        if(input ==  PlayerInput.None) return new PlayerJumpNoDirection();
        player.movementBehaviour.MoveLeft();
        player.animator.SetTrigger(AnimationStruct.Jump);
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        player.movementBehaviour.Stop();
        return;
    }
}
