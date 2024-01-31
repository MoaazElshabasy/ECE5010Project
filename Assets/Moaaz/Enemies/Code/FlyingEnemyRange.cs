using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyRange : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform player;
    private Transform thisTransform;
    public float lineOfSite;
    public float attackRange;
    private float nextAttackTime;
    public float AttackRate = 1f;
    public GameObject BulletObject;
    public GameObject BulletCoordinates;
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
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("Move", true);
        }
        else if (distanceFromPlayer <= attackRange && nextAttackTime < Time.time)
        {
            animator.SetBool("Move", false);
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + AttackRate;
            Instantiate(BulletObject, BulletCoordinates.transform.position, BulletCoordinates.transform.rotation);
        } else
        {
            animator.SetBool("Move", false);
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
