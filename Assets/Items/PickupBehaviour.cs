using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickupBehaviour : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    [SerializeField] private SkillEnum skillEnum;
    [SerializeField] private AudioClip pickupClip;

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
            OnKill();
            Destroy(gameObject);
        }
    }

    private void OnKill()
    {
        AudioSource.PlayClipAtPoint(pickupClip, transform.position, SoundManagerBehaviour.getSfxVolume());
    }
    
}
