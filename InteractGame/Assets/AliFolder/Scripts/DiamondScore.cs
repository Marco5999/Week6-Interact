using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScore : MonoBehaviour
{
      public int bouncerScore = 1; // Score value when the ball hits a bouncer
    public int bumperScore = 2; // Score value when the ball hits a bumper or wall bumper
    public int diamondScore = 5; // Score value when the ball collects a diamond

    ScoreManager scoreManager; // Reference to the ScoreManager script

    void Start()
    {
        // Find the ScoreManager GameObject and get its ScoreManager component
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that triggered the diamond is the ball
        if (other.CompareTag("Ball") && gameObject.CompareTag("Diamond"))
        {
            // Increase the score using the ScoreManager
            scoreManager.IncrementScore(diamondScore);

            // Deactivate the diamond GameObject
            gameObject.SetActive(false);

            // Start a coroutine to respawn the diamond after a delay
            DiamondRespawnManager.Instance.StartRespawnCoroutine(gameObject, 5f); // Adjust delay as needed
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (gameObject.CompareTag("Bouncer"))
            {
                // Increase the score using the ScoreManager
                scoreManager.IncrementScore(bouncerScore);
            }
            else if (gameObject.CompareTag("Bumper") || gameObject.CompareTag("WallBumper"))
            {
                // Increase the score using the ScoreManager
                scoreManager.IncrementScore(bumperScore);
            }
        }
    }
}
