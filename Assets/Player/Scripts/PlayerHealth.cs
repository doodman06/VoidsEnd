using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private static int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private AudioSource deathSound;
    Animator animator;

    private void Awake()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        //Time.timeScale = 0.1f;
    }

    public void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
        if (health <= 0)
        {
            Debug.Log("Player is dead");
            Die();
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

    private void Die()
    {
        animator.SetTrigger(AnimationStruct.Death);
        deathSound.volume = SoundManagerBehaviour.getSfxVolume();
        deathSound.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
