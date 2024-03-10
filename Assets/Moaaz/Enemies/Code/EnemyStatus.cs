using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public Animator animator;
    bool isDead = false;
    private Color originalColor;
    private Renderer objectRenderer;
    private Rigidbody2D rigidbody;
    public AudioSource Src;
    public AudioClip sfx;

    private void Start()
    {
        Src.clip = sfx;
        health = maxHealth;
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    private void Update()
    {
        
        if (isDead)
        {
            rigidbody = GetComponent<Rigidbody2D>();

            rigidbody.gravityScale = 10f;
        }
    }
    public void recieveDamage(float damage)
    {
        
        if (damage > 0)
        {
            Src.clip = sfx;
            //Src.Play();
            health -= damage;
            StartCoroutine(takeDamageEffect(0.1f, Color.red));
        }
        
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
        Invoke("disappear", 1);
        
    }
    void disappear()
    {
        Destroy(gameObject);
    }


    IEnumerator takeDamageEffect(float duration, Color targetColor)
    {

        objectRenderer.material.color = targetColor;
        yield return new WaitForSeconds(duration);
        objectRenderer.material.color = originalColor;
    }

}
