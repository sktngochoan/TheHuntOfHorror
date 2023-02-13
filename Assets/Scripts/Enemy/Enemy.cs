using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 4;
    public int curentHealth;
    Animator animator;
    Timer deathTimer;

    void Start()
    {
        // Set max health for enemy
        curentHealth = health;
        // Create time runner to delete enemy
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = 2f;
        // Aimation
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Delete enemy
        if (deathTimer.Finished && curentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Rigidbody2D rigidbody2D = coll.gameObject.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        if (coll.gameObject.CompareTag("Bullet"))
        {
            takeDamage(1);
            if (curentHealth <= 0)
            {
                deathTimer.Run();
                animator.SetTrigger("Dead");
            }
            Destroy(coll.gameObject);
        }
    }

    void takeDamage(int damage)
    {
        curentHealth -= damage;
    }
}
