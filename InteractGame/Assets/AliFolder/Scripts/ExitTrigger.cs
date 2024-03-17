using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D Collider2D;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<Collider2D>();

        spriteRenderer.enabled = false;
        Collider2D.isTrigger = true;
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(BecomeVisibleAndCollidable());
        }
    }

    IEnumerator BecomeVisibleAndCollidable()
    {
        
        yield return new WaitForSeconds(1f);

        
        spriteRenderer.enabled = true;
        Collider2D.isTrigger = false;
    }

    public void ResetTrigger()
    {
        if(spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        
        Collider2D.isTrigger = true;
    }
}
