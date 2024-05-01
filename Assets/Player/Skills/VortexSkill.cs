using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexSkill : Skill
{
    [SerializeField] private GameObject vortexPrefab;
    private Vector2 vortexPosition;
    

    public void UseSkill()
    {
        Debug.Log("Vortex skill used");
        SpawnVortex();
    }

    private void SpawnVortex()
    {
        vortexPosition = transform.position;
        //spawn a vortex
        Instantiate(vortexPrefab, vortexPosition, Quaternion.identity);

    }

    public void UseSkillAtPosition(Vector2 pos)
    {
        if(skillNumber > 0)
        {
            skillNumber--;
            vortexPosition = pos;
            Instantiate(vortexPrefab, vortexPosition, Quaternion.identity);
            PlaySFX();
            UpdateUIInfo();
        }
        
    }

    public override IPlayerState GetState()
    {
        return new PlayerUsingVortexSkill();
    }
}
