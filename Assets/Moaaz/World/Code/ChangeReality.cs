using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenSpriteOnKeyPress : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isChasmReality = false;
    private Color originalColor;
    private Color darkenedColor = new Color(0.2f, 0.2f, 0.2f);

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            isChasmReality = !isChasmReality;

            if (isChasmReality)
            {
                spriteRenderer.color = darkenedColor;
            }
            else
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
}

