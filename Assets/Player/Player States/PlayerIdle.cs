using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.animator.SetTrigger(AnimationStruct.Idle);
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {
        if(input == PlayerInputEnum.Skill) return player.getActiveSkillState();
        if(input == PlayerInputEnum.Jump && player.jumpBehaviour.IsGrounded()) return new PlayerJumping();
        if(!player.jumpBehaviour.IsGrounded()) return new PlayerJumpNoDirection();
        if (input == PlayerInputEnum.MoveRight) return new PlayerMovingRight();
        if (input == PlayerInputEnum.MoveLeft) return new PlayerMovingLeft();
        player.animator.SetTrigger(AnimationStruct.Idle);
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        return;
    }

}
