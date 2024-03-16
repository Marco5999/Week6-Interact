using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    public AudioClip bounceSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bouncer"))
        { 
            audioSource.PlayOneShot(bounceSound);
        }
    }
}
