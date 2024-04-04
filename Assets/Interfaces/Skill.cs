using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected int skillNumber;

    public void AddUses(int amount)
    {
        skillNumber += amount;
    }

    public int GetUses()
    {
        return skillNumber;
    }

    public abstract IPlayerState GetState();
    public abstract void UseSkill();

}
