using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeDamage : MonoBehaviour
{
    public float damage;
    public float finalDamage;
    //public EnemyStatus status;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            finalDamage = damage;
        }

        if (Input.GetMouseButtonDown(1))
        {
            finalDamage = damage * 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            finalDamage = damage * 1.7f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.collider.transform.parent != null && contact.collider.transform.parent.CompareTag("Enemy"))
            {
                GameObject enemy = contact.collider.transform.parent.gameObject;
                EnemyStatus enemyStatus = enemy.GetComponent<EnemyStatus>();
                if (enemyStatus != null)
                {
                    enemyStatus.recieveDamage(finalDamage);
                    finalDamage = 0;
                }
            }
        }
    }

}

