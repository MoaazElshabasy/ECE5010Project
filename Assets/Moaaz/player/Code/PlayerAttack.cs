using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public AudioSource Src;
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackOne");
            Src.clip = sfx1;
            Src.Play();
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("AttackTwo");
            Src.clip = sfx2;
            Src.Play();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("AttackThree");
            Src.clip = sfx3;
            Src.Play();
        }
    }

}
