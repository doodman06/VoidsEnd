using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexSkillBehaviour : MonoBehaviour, ISkill
{
    [SerializeField] private GameObject vortexPrefab;
    private Vector2 vortexPosition;
    

    public  void UseSkill()
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
}
