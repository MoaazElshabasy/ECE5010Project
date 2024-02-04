using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyControl : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Transform thisTransform;
    public float lineOfSite;
    public float attackRange;
    private float nextAttackTime;
    public Animator animator;
    public float AttackRate = 1f;
    private bool inRange;

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
            inRange = true;
            animator.SetBool("Move", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackRange && nextAttackTime < Time.time)
        {
            
            animator.SetBool("Move", false);
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + AttackRate;
        }
        else
        {
            inRange = false;
            animator.SetBool("Move", false);
        }
        Flip(inRange);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Flip(bool doFlip)
    {
        if (doFlip)
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
}
