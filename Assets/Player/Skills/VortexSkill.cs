using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexSkill : MonoBehaviour, ISkill
{
    [SerializeField] private GameObject vortexPrefab;
    private Vector2 vortexPosition;
    [SerializeField] private int skillNumber;
    

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
        }
        
    }

    public void AddUses(int amount)
    {
        skillNumber += amount;
    }

    public int GetUses()
    {
        return skillNumber;
    }

    public IPlayerState GetState()
    {
        return new PlayerUsingVortexSkill();
    }
}
