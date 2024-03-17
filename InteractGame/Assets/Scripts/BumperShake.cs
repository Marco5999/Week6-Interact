using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperShake : MonoBehaviour
{
    // Duration and magnitude of the shake
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.1f;

    private Vector3 originalPosition;
    private Vector3 currentPosition; // Store the current position of the bumper

    void Start()
    {
        originalPosition = transform.position; // Store the original position of the bumper
        currentPosition = originalPosition; // Initialize the current position
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider that hit the bumper has the tag "Ball"
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        // Store the position before shaking
        Vector3 preShakePosition = transform.position;

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = currentPosition.x + Random.Range(-1f, 1f) * shakeMagnitude;
            float y = currentPosition.y + Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = new Vector3(x, y, currentPosition.z);
            elapsed += Time.deltaTime;

            yield return null; // Wait until next frame
        }

        // Restore the position before shaking
        transform.position = preShakePosition;
    }

    // Update the current position of the bumper when it's moved
    void LateUpdate()
    {
        currentPosition = transform.position;
    }
}
