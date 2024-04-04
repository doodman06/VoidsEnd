using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private IPlayerState currentState;

    private IPlayerState newState;

    private PlayerInput currentInput;

    private Vector3 mousePos;

    private Skill[] skills;

    private int currentSkillIndex;

    private void Start()
    {
        //get all skills from the player
        skills = gameObject.GetComponents<Skill>();
        
        //set the first skill as active
        currentSkillIndex = 0;

        currentState = new PlayerIdle();
        currentState.Enter(this);
    }

    public void SetActiveSkill(int index)
    {
        currentSkillIndex = index;
    }

    public void switchSkill()
    {
        currentSkillIndex++;
        if (currentSkillIndex >= skills.Length)
        {
            currentSkillIndex = 0;
        }
    }

    public void AddSkill<T>(int amount)
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].GetType() == typeof(T))
            {
                skills[i].AddUses(amount);
                return;
            }
        }
    }

    public int GetActiveSkillNumber()
    {
        return skills[currentSkillIndex].GetUses();
    }

    public IPlayerState getActiveSkillState()
    {
        if (skills[currentSkillIndex].GetUses() > 0)
        {
            return skills[currentSkillIndex].GetState();
        }
        return null;
    }
    public void setCurrentInput(PlayerInput input)
    {
        currentInput = input;
        UpdateState(currentInput);
    }

    public void setMousePos(Vector3 pos)
    {
        mousePos = pos;
    }

    public Vector3 getMousePos()
    {
        return mousePos;
    }

    /*private void Update()
    {
        UpdateState(currentInput);
    }*/

    public void UpdateState(PlayerInput input)
    {
        newState = currentState.Tick(this, currentInput);

        if(newState != null)
        {
            currentState.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }
        //Debug.Log(currentState.GetType().Name);
    }
}
