using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpNoDirection : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        if (player.GetComponent<JumpBehaviour>().IsGrounded()) return new PlayerIdle();
        if (input == PlayerInput.MoveLeft) return new PlayerJumpingLeft();
        if (input == PlayerInput.MoveRight) return new PlayerJumpingRight();

        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        return;
    }
}
