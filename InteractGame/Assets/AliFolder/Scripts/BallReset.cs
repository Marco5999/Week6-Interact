using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    // In case the ball gets stuck somewhere and the player cant move unless they restart the game

    public Transform respawnPoint; // Respawn point for the ball
    public float idleTimeThreshold = 10f; // Time threshold for considering the ball as idle
    private Vector3 lastPosition; // Store the last position of the ball
    private float idleTimer = 0f; // Timer for tracking idle time

    void Start()
    {
        lastPosition = transform.position; // Initialize the last position
    }

    void Update()
    {
        // Check if the ball has moved since the last frame
        if (transform.position != lastPosition)
        {
            // Reset the idle timer if the ball has moved
            idleTimer = 0f;
            lastPosition = transform.position;
        }
        else
        {
            // Increment the idle timer if the ball hasn't moved
            idleTimer += Time.deltaTime;

            // Check if the idle timer has exceeded the threshold
            if (idleTimer >= idleTimeThreshold)
            {
                // Reset the ball position to the respawn point
                transform.position = respawnPoint.position;
            }
        }
    }

}
