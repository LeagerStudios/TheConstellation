using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2_Manager : MonoBehaviour
{

    PlayerM2 playerScript;
    [SerializeField] GameObject player;

    public float changeGravityTimer;

    void Start()
    {

        playerScript = FindObjectOfType<PlayerM2>();
        changeGravityTimer = 5f;

    }

    void Update()
    {

        changeGravityTimer += Time.deltaTime;

        

        if (Input.GetKeyDown(KeyCode.C) && player.GetComponent<Rigidbody2D>().gravityScale == 1 && changeGravityTimer >= 5 )
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1;

            changeGravityTimer = 0f;

        }

        if (Input.GetKeyDown(KeyCode.C) && player.GetComponent<Rigidbody2D>().gravityScale == -1 && changeGravityTimer >= 5)
        {

            player.GetComponent<Rigidbody2D>().gravityScale = 1;

            changeGravityTimer = 0f;

        }

        if (playerScript.playerHealth == 0)
        {
            gameObject.SetActive(false);
            Debug.Log("Te has hecho la murición pro max");
        }


    }

}
