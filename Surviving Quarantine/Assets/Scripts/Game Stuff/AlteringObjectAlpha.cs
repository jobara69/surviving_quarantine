using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlteringObjectAlpha : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}
