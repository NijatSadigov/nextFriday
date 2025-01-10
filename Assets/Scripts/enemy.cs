using System;
using UnityEngine;

public class enemy : MonoBehaviour
{

    private Collider2D enemyCollider;
    private Rigidbody2D enemyRigidbody;
    private Animator enemyAnimator;
    private bool isDead = false;
    private SpriteRenderer spriteRenderer;

    //patroling
    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;
    private Transform currentPoint;
    public float speed=3f;
    void Start()
    {
        // Get the enemy's Collider2D, Rigidbody2D, and Animator components
        enemyCollider = GetComponent<Collider2D>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
       if(!isDead) { 
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            enemyRigidbody.linearVelocity = new Vector2(speed, 0);

                //Debug.Log(1);
        }
        else
        {
            enemyRigidbody.linearVelocity = new Vector2(-speed, 0);

             //   Debug.Log(2);

        }
        if ((Vector2.Distance(transform.position, currentPoint.position)) < 0.9f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
                spriteRenderer.flipX = true; // Flip to face left

            }
            if ((Vector2.Distance(transform.position, currentPoint.position)) < 0.9f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
                spriteRenderer.flipX = false; // Flip to face left

            }
       }

        if (transform.position.y < -20)
        {
            Destroy(gameObject); // Destroy the enemy
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the enemy collided with the player
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
      
        // Flip the enemy upside down
        transform.Rotate(0, 0, 90);

        // Disable the collider
        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        // Disable the rigidbody's physics by freezing it
        if (enemyRigidbody != null)
        {
           // enemyRigidbody.bodyType = RigidbodyType2D.Static;
        }

        // Stop the enemy's animation
        if (enemyAnimator != null)
        {
            enemyAnimator.enabled = false;
        }

        // Optionally, you can add additional logic here (e.g., play a sound or animation)
        Debug.Log("Enemy has died.");
    }
}
