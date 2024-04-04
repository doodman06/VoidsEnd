using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsingDashSkill : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {
        player.GetComponent<DashSkill>().UseSkill();
        return new PlayerIdle();
    }

    public void Exit(PlayerBehaviour player)
    {
        player.GetComponent<MovementBehaviour>().Stop();
        return;
    }
}
