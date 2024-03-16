using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    public AudioClip bounceSound; 
    public AudioClip BumperSound;
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

        if (other.gameObject.CompareTag("Bumper"))
        { 
            audioSource.PlayOneShot(BumperSound);
        }
    }
}
