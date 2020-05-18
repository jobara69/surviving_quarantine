using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private int thisScore;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") && other.isTrigger)
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Alien") && other.isTrigger)
        {
            var textUIScore = GameObject.Find("Points Number").GetComponent<TextMeshProUGUI>();
            int score = int.Parse(textUIScore.text);
            score += 10;
            textUIScore.text = score.ToString();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
