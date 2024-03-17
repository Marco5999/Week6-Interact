using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public float initialLaunchForce = 10f;
    public float maxLaunchForce = 20f;
    public float chargeRate = 2f; 

    private float currentLaunchForce;
    private bool ballInLauncher = false;

    public GameObject trigger;
    ExitTrigger exitTrigger;

    public float CurrentLaunchForce => currentLaunchForce;
    public float MaxLaunchForce => maxLaunchForce;

    void Start()
    {
        currentLaunchForce = initialLaunchForce;
        exitTrigger = trigger.GetComponent<ExitTrigger>();
    }

    void Update()
    {
        
        if (ballInLauncher)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                currentLaunchForce += chargeRate * Time.deltaTime;
                currentLaunchForce = Mathf.Clamp(currentLaunchForce, initialLaunchForce, maxLaunchForce);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                LaunchBall();
                currentLaunchForce = initialLaunchForce; 
            }
        }
    }

    void LaunchBall()
    {
        
        ballRigidbody.AddForce(Vector2.up * currentLaunchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            
            ballInLauncher = true;
            exitTrigger.ResetTrigger();
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
