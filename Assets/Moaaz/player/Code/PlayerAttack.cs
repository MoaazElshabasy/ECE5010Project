using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackOne");
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("AttackTwo");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("AttackThree");
        }
    }

}
