using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickupBehaviour : MonoBehaviour
{
    private SkillManager skillManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        skillManager = collision.GetComponent<SkillManager>();
        if (skillManager != null)
        {
            skillManager.AddSkill<VortexSkill>(1);
            
            Destroy(gameObject);
        }
    }
    
}
