using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingLeft : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.Notify(EventEnum.Move);
        player.GetComponent<SpriteRenderer>().flipX = true;
        player.animator.SetTrigger("Run");
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Skill) return player.getActiveSkillState();
        if (input == PlayerInput.Jump && player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerJumping();
        if (input == PlayerInput.MoveRight) return new PlayerMovingRight();
        if (input == PlayerInput.None) return new PlayerIdle();
        player.GetComponent<MovementBehaviour>().MoveLeft();
        player.animator.SetTrigger("Run");
        return null;

    }

    public void Exit(PlayerBehaviour player)
    {
        player.GetComponent<MovementBehaviour>().Stop();
        return;
    }
}
