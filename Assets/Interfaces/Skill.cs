using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected int skillNumber;
    [SerializeField] protected AudioSource sfx;
    [SerializeField] protected TrailRenderer trailRenderer;

    public void AddUses(int amount)
    {
        skillNumber += amount;
    }

    public int GetUses()
    {
        return skillNumber;
    }

    public abstract IPlayerState GetState();
    public void UpdateUIInfo()
    {
        SkillUIBehaviour.UpdateSkill();
        Debug.Log("Skill used");
    }

    protected void PlaySFX()
    {
        sfx.volume = SoundManagerBehaviour.getSfxVolume();
        sfx.Play();
    }

    protected void StartEmitting()
    {
        trailRenderer.emitting = true;
    }
}
