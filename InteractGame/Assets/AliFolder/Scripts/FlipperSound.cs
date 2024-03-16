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
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(flipperSound);
        }
    }
}
