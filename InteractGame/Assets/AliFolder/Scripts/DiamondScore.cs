using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScore : MonoBehaviour
{
      public int scoreValue = 100; // Score value to increase when collected

    ScoreManager scoreManager; // Reference to the ScoreManager script

    void Start()
    {
        // Find the ScoreManager GameObject and get its ScoreManager component
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that triggered the diamond is the ball
        if (other.CompareTag("Ball"))
        {
            // Increase the score using the ScoreManager
            scoreManager.IncrementScore(scoreValue);

            // Deactivate the diamond GameObject
            gameObject.SetActive(false);

            // Start a coroutine to respawn the diamond after a delay
            DiamondRespawnManager.Instance.StartRespawnCoroutine(gameObject, 5f); // Adjust delay as needed
        }
    }
}
