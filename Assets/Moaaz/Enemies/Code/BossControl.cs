using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public GameObject[] objectsToInstantiate;
    public float xMin, xMax , yMin, yMax  = 0;
    public float teleportDelay = 2f;
    public float spawnObjectDelay = 2f;
    private Transform player;
    private Transform thisTransform;
    private bool isHit = false;
    private float teleportTimer = 0f;
    private float spawnObjectTimer = 0f;
    public float initialHealth;
    public GameObject BulletCoordinates;
    public GameObject BulletCoordinates1;
    public GameObject BulletCoordinates2;
    public Animator animator;
    private EnemyStatus enemyStatus;

    void Start()
    {
        enemyStatus = GetComponent<EnemyStatus>();
        initialHealth = enemyStatus.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisTransform = transform;
    }

    void Update()
    {
        Flip();
        if (isHit)
        {
            Debug.Log(isHit);
            teleportTimer += Time.deltaTime;
            if (teleportTimer >= teleportDelay)
            {
                animator.SetTrigger("Teleport");
                Invoke("TeleportBoss", 1);
                teleportTimer = 0f;
                isHit = false;
            }
        }

        spawnObjectTimer += Time.deltaTime;
        if (spawnObjectTimer >= spawnObjectDelay)
        {
            animator.SetTrigger("Attack");
            Invoke("SpawnRandomObject", 1);
            spawnObjectTimer = 0f;
        }

        if (enemyStatus.health < initialHealth)
        {
            initialHealth = enemyStatus.health;
            isHit = true;
        }
    }

    void TeleportBoss()
    {
        
        float newX = Random.Range(xMin, xMax);
        float newY = Random.Range(yMin, yMax);

        transform.position = new Vector2(newX, newY);
    }

    void SpawnRandomObject()
    {
        if (objectsToInstantiate.Length > 0)
        {
            int random = Random.Range(0, 3);
            int randomIndex = Random.Range(0, objectsToInstantiate.Length);
            GameObject obj = objectsToInstantiate[randomIndex];
            if (random == 3)
            {
                Instantiate(obj, BulletCoordinates.transform.position, BulletCoordinates.transform.rotation);
            }
            else if (random == 3)
            {
                Instantiate(obj, BulletCoordinates.transform.position, BulletCoordinates.transform.rotation);
            } 
            else
            {
                Instantiate(obj, BulletCoordinates.transform.position, BulletCoordinates.transform.rotation);
                Instantiate(obj, BulletCoordinates1.transform.position, BulletCoordinates1.transform.rotation);
                Instantiate(obj, BulletCoordinates2.transform.position, BulletCoordinates2.transform.rotation);
            }
            
        }
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
