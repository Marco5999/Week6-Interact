using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotShake : MonoBehaviour

{
    // Duration and magnitude of the shake
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.1f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

   

    public void StartShake()
    {
        StartCoroutine(Shake());
    }


    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = originalPosition.x + Random.Range(-1f, 1f) * shakeMagnitude;
            float y = originalPosition.y + Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        
        transform.position = originalPosition;
    }
}
