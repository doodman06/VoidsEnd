using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsingSkill : IPlayerState
{

    private Skill currentSkill;
    public void Enter(PlayerBehaviour player)
    {
        currentSkill = player.GetActiveSkill();
        //check the type of the skill and notify the observers
        switch(player.GetActiveSkillType())
        {
            case SkillEnum.Dash:
                player.Notify(EventEnum.Dash);
                break;
            case SkillEnum.Vortex:
                player.Notify(EventEnum.Vortex);
                break;
        }

        currentSkill.StartSkill();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {

        if (currentSkill.UpdateSkill(input)) return new PlayerIdle();

        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        currentSkill.EndSkill();
        return;
    }
}
