using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    [SerializeField] private float dashVelocity;
    [SerializeField] private float dashTime;
   
    public void UseSkill()
    {
        Debug.Log("Dash skill used");
        Dash();
    }

    private void Dash()
    {
        PlaySFX();
       
        skillNumber--;
        UpdateUIInfo();
    }

    public override IPlayerState GetState()
    {
        return new PlayerUsingDashSkill();
    }

    public float GetDashVelocity()
    {
        return dashVelocity;
    }
    public float GetDashTime()
    {
        return dashTime;
    }
}
