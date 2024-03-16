using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the ball collided with the respawn collider
        if (other.CompareTag("RespawnCollider"))
        {
            RespawnBall();
        }
    }

    void RespawnBall()
    {
        // Move the ball to the respawn point
        transform.position = respawnPoint.position;

        // Optionally reset any velocity or angular velocity
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
