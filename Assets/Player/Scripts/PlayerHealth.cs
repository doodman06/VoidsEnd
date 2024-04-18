using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static int health;
    [SerializeField] private int maxHealth;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
        if (health <= 0)
        {
            Debug.Log("Player is dead");
        }
    }

    private void ChangeHealth(int amount)
    {
        health += amount;
        HealthUIBehaviour.UpdateHealth();
    }

    public static int getHealth()
    {
        return health;
    }
}
