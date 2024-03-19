using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingBehaviour : MonoBehaviour
{
    [SerializeField] private int damage;

    private PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
       if(playerHealth != null)
       {
            playerHealth.TakeDamage(damage);
       }
    }
}
