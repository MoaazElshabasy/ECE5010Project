using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingStatue : MonoBehaviour
{

    [SerializeField]
    public SpriteRenderer popUpText;
    private bool Triggered;
    public Animator animator;
    public PlayerStatus status;
    public int healing;
    public float animationDuration = 1f;
    private void Start()
    {
        popUpText.enabled = false;
    }

    private void Update()
    {
        if (Triggered && Input.GetKeyDown(KeyCode.E))
        {
            Action();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            popUpText.enabled = true;
            Triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            popUpText.enabled = false;
            Triggered = false;
        }
    }

    private void Action()
    {
        status.recieveHealing(healing);
        popUpText.enabled = false;
        animator.SetTrigger("Destroy");
        Invoke("Disappear", animationDuration);
    }

    private void Disappear()
    {
        
        Destroy(gameObject);
    }

}
