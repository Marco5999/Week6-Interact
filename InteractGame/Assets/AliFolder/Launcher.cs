using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public float initialLaunchForce = 10f;
    public float maxLaunchForce = 20f;
    public float chargeRate = 2f; // Rate at which the launch force increases while holding space

    private float currentLaunchForce;
    private bool ballInLauncher = false;

    public float CurrentLaunchForce => currentLaunchForce;
    public float MaxLaunchForce => maxLaunchForce;

    void Start()
    {
        currentLaunchForce = initialLaunchForce;
    }

    void Update()
    {
        // Check for input (space bar) only when the ball is in the launcher
        if (ballInLauncher)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // Increase the launch force gradually while space bar is held down
                currentLaunchForce += chargeRate * Time.deltaTime;
                currentLaunchForce = Mathf.Clamp(currentLaunchForce, initialLaunchForce, maxLaunchForce);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                LaunchBall();
                currentLaunchForce = initialLaunchForce; // Reset launch force after releasing space bar
            }
        }
    }

    void LaunchBall()
    {
        // Apply force to the ball
        ballRigidbody.AddForce(Vector2.up * currentLaunchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Set ballInLauncher to true when the ball enters the launcher
            ballInLauncher = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the colliding object is the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Set ballInLauncher to false when the ball exits the launcher
            ballInLauncher = false;
        }
    }
}
