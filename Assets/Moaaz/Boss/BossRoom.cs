using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public EnemyStatus enemyStatus;
    private SpriteRenderer PortalSprite;
    private Collider2D[] PortalCollide;
    private int health;
    private int maxHealth;
    public HealthBar healthBar;
    public AudioSource Src;
    public AudioClip sfx;
    bool bossDead = false;
    void Start()
    {
        PortalSprite = GetComponent<SpriteRenderer>();
        PortalCollide = GetComponents<Collider2D>();
        maxHealth = (int)enemyStatus.maxHealth;
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Update()
    {
        health = (int)enemyStatus.health;
        healthBar.setHealth(health);
       
        
        if (enemyStatus.health <= 0 && !bossDead)
        {
            bossDead = true;
            Src.clip = sfx;
            Src.Play();
            PortalSprite.enabled = true;
            foreach (Collider2D collider in PortalCollide)
            {
                collider.enabled = true;
            }


        }
    }
}
