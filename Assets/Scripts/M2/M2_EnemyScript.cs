using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2_EnemyScript : MonoBehaviour
{

    PlayerM2 playerAttributes;

    RaycastHit2D checkCollisionLeft;
    RaycastHit2D checkCollisionRight;
    [SerializeField] LayerMask Ground;

    void Start()
    {
        playerAttributes = FindObjectOfType<PlayerM2>();
    }

    void Update()
    {

        checkCollisionLeft = Physics2D.Raycast(transform.position, Vector2.left, 1.01f, Ground);
        checkCollisionRight = Physics2D.Raycast(transform.position, Vector2.right, 1.01f, Ground);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {

            playerAttributes.playerHealth -= 20;

            Debug.Log(playerAttributes.playerHealth);

        }

    }

}
