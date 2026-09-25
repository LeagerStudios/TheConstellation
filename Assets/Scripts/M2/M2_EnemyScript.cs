using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2_EnemyScript : MonoBehaviour
{

    PlayerM2 playerAttributes;

    void Start()
    {
        playerAttributes = FindObjectOfType<PlayerM2>();
    }

    void Update()
    {
        
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
