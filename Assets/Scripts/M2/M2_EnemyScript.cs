using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2_EnemyScript : MonoBehaviour
{

    PlayerM2 playerAttributes;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;

    RaycastHit2D checkCollisionLeft;
    RaycastHit2D checkCollisionRight;

    public float enemySpeed;
    bool changeDirection;

    void Start()
    {

        playerAttributes = FindObjectOfType<PlayerM2>();

        enemySpeed = 3.25f;

        rb.gravityScale = 0;

    }

    void Update()
    {

        checkCollisionLeft = Physics2D.Raycast(transform.position, Vector2.left, 1.001f);
        checkCollisionRight = Physics2D.Raycast(transform.position, Vector2.right, 1.001f);



        if (checkCollisionRight.collider != null  && checkCollisionRight.collider.CompareTag("Ground"))
        {
            changeDirection = true;

        }

        if (checkCollisionLeft.collider != null && checkCollisionLeft.collider.CompareTag("Ground"))
        {
            changeDirection = false;
        }

    }

    private void FixedUpdate()
    {

        if (changeDirection)
        {

            rb.velocity = new Vector2(-enemySpeed, rb.velocity.y);
            sr.flipX = true;

        }
        else
        {
            rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
            sr.flipX = false;
        }

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            playerAttributes.playerHealth -= 20;
        }

    }

}
