using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth = 100;
    public GameObject deathEffect;
    public int health;
    public Animator animator;


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
            health = 0;
            Die();
            
        }
    }
    void Die()
    {
        Debug.Log("Oh No Cringe");
    }
}

