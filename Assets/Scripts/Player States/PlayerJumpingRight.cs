using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingRight : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.GetComponent<SpriteRenderer>().flipX = false;
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerIdle();
        if(input == PlayerInput.MoveLeft) return new PlayerJumpingLeft();
        if(input == PlayerInput.None) return new PlayerJumpNoDirection();
        player.GetComponent<MovementBehaviour>().Move(1);

        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        player.GetComponent<MovementBehaviour>().Stop();
        return;
    }
}
