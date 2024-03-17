using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherSound : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public float launchForce = 10f;
    public AudioClip launchSound; 
    private AudioSource audioSource;

    private bool ballInLauncher = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (ballInLauncher && Input.GetKeyUp(KeyCode.LeftShift))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {   
        audioSource.PlayOneShot(launchSound);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballInLauncher = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballInLauncher = false;
        }
    }
}
