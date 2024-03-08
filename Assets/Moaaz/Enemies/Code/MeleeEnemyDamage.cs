using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyDamage : MonoBehaviour
{
    public int damage;
    private int finalDamage;
    public PlayerStatus status;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            finalDamage = damage; 
            status.recieveDamage(finalDamage);
            finalDamage = 0;
        }
    }
}
