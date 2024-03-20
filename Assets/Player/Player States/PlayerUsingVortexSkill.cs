using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsingVortexSkill : IPlayerState
{
    public void Enter(PlayerBehaviour player)
    {
        //slow time
        Time.timeScale = 0.1f;
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInput input)
    {   
        if (input == PlayerInput.MouseClick)
        {
            player.GetComponent<VortexSkill>().UseSkillAtPosition(player.getMousePos());
            return new PlayerIdle();

        } 
        return null;
    }


    public void Exit(PlayerBehaviour player)
    {
        //unfreeze time
        Time.timeScale = 1f;
        return;
    }
}
