using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingLeft : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (input == PlayerInput.Jump && player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerJumping();
        if (input == PlayerInput.None) return new PlayerIdle();
        player.GetComponent<MovementBehaviour>().Move(-1);
        return null;

    }

    public void Exit(PlayerBehaviour player)
    {
        player.GetComponent<MovementBehaviour>().Stop();
        return;
    }
}
