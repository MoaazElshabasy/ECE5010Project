using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: the following code belongs to youtube channel Anup Prasad
public class FollowCamera : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;
    public float yOffset = 2f;

    // Variables for camera shaking
    private bool isShaking = false;
    private float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.1f;

    void Update()
    {
        // Check if the 'F' key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Trigger camera shake
            StartCoroutine(ShakeCamera(shakeDuration, shakeMagnitude));
        }

        // Calculate the new position with the yOffset
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);

        // Move the camera towards the target directly without smoothing
        transform.position = targetPosition;
    }

    IEnumerator ShakeCamera(float duration, float magnitude)
    {
        isShaking = true;
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
        isShaking = false;
    }
}


