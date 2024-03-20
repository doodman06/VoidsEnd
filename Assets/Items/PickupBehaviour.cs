using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickupBehaviour : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerBehaviour = collision.GetComponent<PlayerBehaviour>();
        if (playerBehaviour != null)
        {
            playerBehaviour.AddSkill<VortexSkill>(1);
            
            Destroy(gameObject);
        }
    }
    
}
