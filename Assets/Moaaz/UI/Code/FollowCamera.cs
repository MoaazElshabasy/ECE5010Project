using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: the following code belongs to youtube channel Anup Prasad
public class FollowCamera : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;
    public float yOffset = 2f;

    void Update()
    {
        // Calculate the new position with the yOffset
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);

        // Move the camera towards the target directly without smoothing
        transform.position = targetPosition;
    }
}

