using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int health = 20;
    public int curentHealth;
    public HealthBar healthBar;
    Animator animator;
    Timer deathTimer;
    private Canvas canvas;

    void Start()
    {
        // Set max health for enemy
        curentHealth = health;
        healthBar.setMaxHealth(health);
        // Create time runner to delete enemy
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = 2f;
        // Aimation
        animator = GetComponent<Animator>();
        // Health bar
        canvas = gameObject.GetComponentInChildren<Canvas>();
    }

    private void Update()
    {
        // Delete health bar when enemy is death
        if (canvas != null && curentHealth <= 0)
        {
            Destroy(canvas.gameObject);
        }

        // Delete enemy
        if (deathTimer.Finished && curentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;
        takeDamage((int)collision.GetComponent<Bullet>().damage);
        if (curentHealth > 0)
        {
        }
        else
        {
            deathTimer.Run();
            animator.SetTrigger("Dead");
        }

    }

    void takeDamage(int damage)
    {
        curentHealth -= damage;
        healthBar.SetHealth(curentHealth);
    }
}
