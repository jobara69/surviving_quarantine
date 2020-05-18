using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceMoviment : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [HideInInspector] public float h_move;
    [SerializeField] private Sprite explosiveShip;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private TextMeshProUGUI scorePoints;
    [SerializeField] private TextMeshProUGUI finalScore;
    public int score;

    private void OnEnable()
    {
        score = 0;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(h_move * moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Alien") && other.isTrigger)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = explosiveShip;
            StartCoroutine(PlayerDeath());
        }

        if (other.CompareTag("AlienBullet") && other.isTrigger)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = explosiveShip;
            StartCoroutine(PlayerDeath());
        }
    }

    private IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(0.2f);
        score = int.Parse(scorePoints.text);
        finalScore.text = score.ToString();
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(h_move * moveSpeed, 0);
    }
}
