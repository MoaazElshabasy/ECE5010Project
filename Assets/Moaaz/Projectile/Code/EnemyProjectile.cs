using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    GameObject target;
    //public PlayerStatus status;
    public float speed;
    Rigidbody2D Rigidbody;
    public int damage = 25;
    public GameObject impactEffect;
    public int projectileLife;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        Rigidbody.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, projectileLife);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerStatus player = hitInfo.GetComponent<PlayerStatus>();
        if (player != null)
        {
            player.recieveDamage(damage);
        }
        //Instantiate(impactEffect, transform.position, Quaternion.identity);
        //Debug.Log(hitInfo.name);

        Destroy(gameObject);


    }
}
