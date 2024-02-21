using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public Animator animator;
    bool isDead = false;

    private void Start()
    {
        health = maxHealth;
    }
    public void recieveDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
             health = 0;
             Die();
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
        Invoke("disappear", 2);
        
    }
    void disappear()
    {
        Destroy(gameObject);
    }

}
