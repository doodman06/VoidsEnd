using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected int skillNumber;
    [SerializeField] protected AudioSource sfx;

    public void AddUses(int amount)
    {
        skillNumber += amount;
    }

    public abstract void StartSkill();
    public abstract void EndSkill();

    public abstract bool UpdateSkill(PlayerInputEnum input);

    public int GetUses()
    {
        return skillNumber;
    }

   
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
}
