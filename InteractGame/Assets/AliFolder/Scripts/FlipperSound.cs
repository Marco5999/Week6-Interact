using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperSound : MonoBehaviour
{
   public AudioClip flipperSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            audioSource.PlayOneShot(flipperSound);
        }
    }
}
