using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyControl : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Transform thisTransform;
    public float lineOfSite;
    public float attackRange;
    private float nextAttackTime;
    public Animator animator;
    public float AttackRate = 0.5f;
    public GameObject BulletObject;
    public GameObject BulletCoordinates;
    public AudioSource Src;
    public AudioClip sfx;

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
            animator.SetBool("Move", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackRange && nextAttackTime < Time.time)
        {
            Src.clip = sfx;
            Src.Play();
            animator.SetBool("Move", false);
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + AttackRate;
            Invoke("InstantiateProjectile", AttackRate);
        }
        else
        {
            animator.SetBool("Move", false);
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
