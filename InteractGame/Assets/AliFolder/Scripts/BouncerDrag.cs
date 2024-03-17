using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    BumperShake shake;
    Collider2D col;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        shake = GetComponent<BumperShake>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPosition();
        isDragging = true;
        col.enabled = false;
        SetTransparency(0.3f);


    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            
            float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
            
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        shake.currentPosition = transform.position;
        col.enabled = true;
        SetTransparency(1f);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; 
        return mouseWorldPosition;
    }

    private void SetTransparency(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}
