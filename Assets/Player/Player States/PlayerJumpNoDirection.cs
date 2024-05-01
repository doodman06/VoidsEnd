using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpNoDirection : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.animator.SetTrigger("Jump");
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (player.jumpBehaviour.IsGrounded()) return new PlayerIdle();
        if (player.jumpBehaviour.IsFalling()) return new PlayerFalling();
        if (input == PlayerInput.MoveLeft) return new PlayerJumpingLeft();
        if (input == PlayerInput.MoveRight) return new PlayerJumpingRight();
        player.animator.SetTrigger("Jump");
        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        return;
    }
}
