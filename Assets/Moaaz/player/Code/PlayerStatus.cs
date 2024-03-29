//using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public Animator animator;
    bool isDead = false;
    private Color originalColor;
    private Renderer objectRenderer;
    public HealthBar healthBar;

    public UnityEngine.UI.Image popUpMessage;



    private void Start()
    {
        popUpMessage.gameObject.SetActive(false);
        health = maxHealth;
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        healthBar.setMaxHealth(maxHealth);
    }
    public void recieveDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        healthBar.setHealth(health);
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
        healthBar.setHealth(health);
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
        popUpMessage.gameObject.SetActive(true);
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

