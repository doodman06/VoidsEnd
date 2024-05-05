using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsingDashSkill : IPlayerState
{
    private float time = 0f;
    private float timeToDash;
    private bool direction;
    private DashSkill dashSkill;
    public void Enter(PlayerBehaviour player)
    {
        player.Notify(EventEnum.Dash);
        dashSkill = player.GetComponent<DashSkill>();
        direction = player.spriteRenderer.flipX;
        if (direction) 
        {
            player.rb.velocity = player.rb.velocity + new Vector2(-dashSkill.GetDashVelocity(), 0);
        } 
        else
        {
            player.rb.velocity = player.rb.velocity + new Vector2(dashSkill.GetDashVelocity(), 0);
        }
       
        timeToDash = dashSkill.GetDashTime();
        return;
    }

    public IPlayerState Tick(PlayerBehaviour player, PlayerInputEnum input)
    {
        time += Time.deltaTime;
        if (time >= timeToDash) return new PlayerIdle();

        return null;
    }

    public void Exit(PlayerBehaviour player)
    {
        dashSkill.UseSkill();
        player.movementBehaviour.Stop();
        return;
    }
}
