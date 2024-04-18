using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    [SerializeField] private float dashSpeed;
    public void UseSkill()
    {
        Debug.Log("Dash skill used");
        Dash();
    }

    private void Dash()
    {
        //dash in the direction the player is facing
        transform.position += transform.right * dashSpeed * Time.deltaTime;
        skillNumber--;
        UpdateUIInfo();
    }

    public override IPlayerState GetState()
    {
        return new PlayerUsingDashSkill();
    }
}
