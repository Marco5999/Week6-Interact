using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject trigger;
    ExitTrigger exitTrigger;


    private void Start()
    {
        exitTrigger = trigger.GetComponent<ExitTrigger>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("RespawnCollider"))
        {
            RespawnBall();
            exitTrigger.ResetTrigger();
        }
    }

    void RespawnBall()
    {
        transform.position = respawnPoint.position;
 
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
