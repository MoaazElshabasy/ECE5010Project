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
    private Color originalColor;
    private Renderer objectRenderer;


    private void Start()
    {
        health = maxHealth;
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }
    public void recieveDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        StartCoroutine(ColorEffect(0.1f, Color.red));
        if (health <= 0)
        {
                Die();   
        }
    }

    public void recieveHealing(int healing)
    {
        health += healing;
        StartCoroutine(ColorEffect(0.1f, Color.green));
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

    IEnumerator ColorEffect(float duration, Color targetColor)
    {

        objectRenderer.material.color = targetColor;
        yield return new WaitForSeconds(duration);
        objectRenderer.material.color = originalColor;
    }

}

