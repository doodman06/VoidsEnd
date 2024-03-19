using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private ISkill[] skills;

    private int[] skillCounter;

    private int currentSkillIndex;

    private void Start()
    {
        skills = gameObject.GetComponents<ISkill>();
        skillCounter = new int[skills.Length];
        //for now start all skills with 5 uses
        for (int i = 0; i < skillCounter.Length; i++)
        {
            skillCounter[i] = 5;
        }
        //set the first skill as active
        currentSkillIndex = 0;
    }

    public void UseActiveSkill()
    {
        if (skillCounter[currentSkillIndex] > 0)
        {
            skills[currentSkillIndex].UseSkill();
            skillCounter[currentSkillIndex]--;
        }
    }

    public void SetActiveSkill(int index)
    {
        currentSkillIndex = index;
    }

    public void AddSkill<T>(int amount)
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].GetType() == typeof(T))
            {
                skillCounter[i] += amount;
                return;
            }
        }
    }



}
