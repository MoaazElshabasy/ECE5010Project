using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class WalkingEnemyMelee : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Transform thisTransform;
    public float lineOfSite;
    public float attackRange;
    private float nextAttackTime;
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisTransform = transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange)
        {
            animator.SetBool("Walk", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackRange && nextAttackTime < Time.time)
        {
            animator.SetBool("Walk", false);
            animator.SetTrigger("Attack");
        }else
        {
            animator.SetBool("Walk", false);
        }
        
        Flip();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Flip()
    {
        if (player.position.x < thisTransform.position.x)
        {
            thisTransform.localScale = new Vector3(-1, 1, 1); 
        }
        else if (player.position.x > thisTransform.position.x)
        {
            thisTransform.localScale = new Vector3(1, 1, 1); 
        }
    }
}
