using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public float forceStrength;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            
            Vector2 direction = collision.transform.position - transform.position;
            direction.Normalize();

            
            Rigidbody2D ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            ballRigidbody.AddForce(direction * forceStrength);
        }
    }
}
