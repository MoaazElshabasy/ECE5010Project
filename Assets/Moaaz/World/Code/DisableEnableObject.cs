using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D[] colliders;
    public bool isEnabled = true; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliders = GetComponents<Collider2D>();
        spriteRenderer.enabled = isEnabled;
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = isEnabled;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isEnabled = !isEnabled;
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = isEnabled;
            }

            if (colliders != null)
            {
                foreach (Collider2D collider in colliders)
                {
                    collider.enabled = isEnabled;
                }
            }
        }
    }
}




