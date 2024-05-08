using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.animator.SetTrigger(AnimationStruct.Fall);
        player.jumpBehaviour.ApplyFallingGravity();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {
        if (input == PlayerInputEnum.Skill) return new PlayerUsingSkill();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (input == PlayerInputEnum.MoveRight) return new PlayerFallingRight();
        if (input == PlayerInputEnum.MoveLeft) return new PlayerFallingLeft();
        player.animator.SetTrigger(AnimationStruct.Fall);
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        player.jumpBehaviour.ResetGravity();
        return;
    }
}
