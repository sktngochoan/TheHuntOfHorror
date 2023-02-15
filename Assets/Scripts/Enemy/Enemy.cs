using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 4;
    public float curentHealth;
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
        if (deathTimer.Finished && curentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    Rigidbody2D rigidbody2D = coll.gameObject.GetComponent<Rigidbody2D>();
    //    if (rigidbody2D != null)
    //    {
    //        rigidbody2D.velocity = Vector2.zero;
    //    }
    //    if (coll.gameObject.CompareTag("Bullet"))
    //    {
    //        takeDamage(1);
    //        if (curentHealth <= 0)
    //        {
    //            deathTimer.Run();
    //            animator.SetTrigger("Dead");
    //        }
    //        Destroy(coll.gameObject);
    //    }
    //}

    void takeDamage(int damage)
    {
        curentHealth -= damage;
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
            //Dead();
        }

    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
