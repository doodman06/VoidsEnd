using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickupBehaviour : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    [SerializeField] private SkillEnum skillEnum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerBehaviour = collision.GetComponent<PlayerBehaviour>();
        if (playerBehaviour != null)
        {
            if (skillEnum == SkillEnum.Dash)
            {
                playerBehaviour.AddSkill<DashSkill>(1);
            }
            else if (skillEnum == SkillEnum.Vortex)
            {
                playerBehaviour.AddSkill<VortexSkill>(1);
            }
            
            Destroy(gameObject);
        }
    }
    
}
