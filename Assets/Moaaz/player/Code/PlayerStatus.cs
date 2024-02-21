using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public Animator animator;
    bool isDead = false;


    private void Start()
    {
        health = maxHealth;
    }
    public void recieveDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        if (health <= 0)
        {
                Die();   
        }
    }

    public void recieveHealing(int healing)
    {
        health += healing;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void Die()
    {
        if (!isDead)
        {
            animator.SetTrigger("Death");
            isDead = true;
        }
        Component[] components = GetComponents<MonoBehaviour>();

        foreach (Component component in components)
        {

            if (component != this)
            {
                Destroy(component);
            }
        }

    }

}

