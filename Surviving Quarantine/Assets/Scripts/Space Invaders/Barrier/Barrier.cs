using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && other.isTrigger)
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("AlienBullet") && other.isTrigger)
        {
            gameObject.SetActive(false);
        }
    }
}
