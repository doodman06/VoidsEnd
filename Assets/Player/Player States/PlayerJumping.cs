using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.Notify(EventEnum.Jump);
        player.jumpBehaviour.Jump();
        player.animator.SetTrigger(AnimationStruct.Jump);
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {
        if (input == PlayerInputEnum.Skill) return player.getActiveSkillState();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (player.jumpBehaviour.IsFalling()) return new PlayerFalling();
        if (input == PlayerInputEnum.MoveRight) return new PlayerJumpingRight();
        if (input == PlayerInputEnum.MoveLeft) return new PlayerJumpingLeft();
        player.animator.SetTrigger(AnimationStruct.Jump);
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        return;
    }
}
