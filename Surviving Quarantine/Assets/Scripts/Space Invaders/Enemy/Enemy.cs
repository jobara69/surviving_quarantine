using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer thisRenderer;
    [SerializeField] private Sprite deathSprite;
    public float speed;
    [SerializeField] private Sprite startImage;
    [SerializeField] private Sprite altImage;
    [SerializeField] private float secBeforeSpriteChange = 0.5f;
    [SerializeField] private GameObject alienBullet;
    [SerializeField] private float minFireRateTime;
    [SerializeField] private float maxFireRateTime;
    [SerializeField] private float baseFireWaitTime;
    private bool isTouchingWall;
    private Rigidbody2D rb;
    private bool canInstantiate =false;
    private float time = 0;
    [HideInInspector] public bool dead;
    
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        thisRenderer = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(1, 0) * speed;
        StartCoroutine(AlienSpriteChange());
        baseFireWaitTime = Random.Range(minFireRateTime, maxFireRateTime);
        canInstantiate = true;
    }

    private void OnDisable()
    {
        canInstantiate = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && other.isTrigger)
        {
            thisRenderer.sprite = deathSprite;
            gameObject.SetActive(false);
            dead = true;
        }

        if (other.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }
        else if (other.gameObject.name == "RightWall")
        {
            Turn(-1);
            MoveDown();
        }

        if (other.CompareTag("Player") && other.isTrigger)
        {
            gameObject.SetActive(false);
        }
    }

    private void Turn(int direction)
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = speed * direction;
        rb.velocity = newVelocity;
    }

    private void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 0.08f;
        transform.position = position;
    }

    private IEnumerator AlienSpriteChange()
    {
        while (true)
        {
            if (thisRenderer.sprite == startImage)
            {
                thisRenderer.sprite = altImage;
            }
            else
            {
                thisRenderer.sprite = startImage;
            }
            yield return new WaitForSeconds(secBeforeSpriteChange);
        }
    }

    private void FixedUpdate()
    {
        if (canInstantiate)
        {
            time += Time.deltaTime;
        }

        if (time > baseFireWaitTime)
        {
            Instantiate(alienBullet, transform.position, Quaternion.identity);
            baseFireWaitTime = Random.Range(minFireRateTime, maxFireRateTime);
            time = 0;
        }
    }
}
