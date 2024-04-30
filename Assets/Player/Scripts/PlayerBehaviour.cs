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

    private Observer[] observers;

    private Skill[] skills;

    private int currentSkillIndex;

    public Animator animator;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        skills = gameObject.GetComponents<Skill>();
        animator = gameObject.GetComponent<Animator>();
        currentSkillIndex = 0;
    }

    private void Start()
    {
        //get all observer in the scene
        observers = FindObjectsOfType<Observer>();
        

        currentState = new PlayerIdle();
        currentState.Enter(this);
    }

    public void SetActiveSkill(int index)
    {
        currentSkillIndex = index;
    }

    public void switchSkill()
    {
        Notify(EventEnum.Switch);
        currentSkillIndex++;
        if (currentSkillIndex >= skills.Length)
        {
            currentSkillIndex = 0;
        }
        SkillUIBehaviour.UpdateSkill();
    }

    public void AddSkill<T>(int amount)
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].GetType() == typeof(T))
            {
                Notify(EventEnum.CollectSkillItem);
                skills[i].AddUses(amount);
                SkillUIBehaviour.UpdateSkill();
                return;
            }
        }
        SkillUIBehaviour.UpdateSkill();
    }

    public int GetActiveSkillNumber()
    {
        return skills[currentSkillIndex].GetUses();
    }
    public SkillEnum GetActiveSkillType()
    {
        if (skills[currentSkillIndex].GetType() == typeof(VortexSkill))
        {
            return SkillEnum.Vortex;
        } else if (skills[currentSkillIndex].GetType() == typeof(DashSkill))
        {
            return SkillEnum.Dash;
        } else
        {
            return SkillEnum.None;
        }
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

    public void Notify(EventEnum currentEvent)
    {
        for(int i = 0; i < observers.Length; i++)
        {
            observers[i].OnNotify(currentEvent);
        }
    }
}
