using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyRange : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Transform thisTransform;
    public float lineOfSite;
    public float attackRange;
    private float nextAttackTime;
    public Animator animator;
    public float AttackRate = 1f;
    public GameObject BulletObject;
    public GameObject BulletCoordinates;

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
            nextAttackTime = Time.time + AttackRate;
            Invoke("InstantiateProjectile", 0.5f);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        Flip();
    }

    void InstantiateProjectile()
    {
        Instantiate(BulletObject, BulletCoordinates.transform.position, BulletCoordinates.transform.rotation);
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
