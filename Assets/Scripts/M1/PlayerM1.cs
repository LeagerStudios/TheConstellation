using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerM1 : MonoBehaviour
{
    private bool k;
    // private int level;
    public Rigidbody2D rb;
    public float force;
    public float maxSpeed;
    public Vector2 startPos;
    private bool keyPressed;
    public KeyCode keyCode;
    public float maxAngle;
    public float SpeedOfMaxAngle;
    public float elapsedTime = 0f;
    public int elapsedTimeInt = 0;
    public int timeLeft;
    public Generator Generator;
    public int[] levelDurations = { 20, 10, 30 }; //obviamente van a durar más, esto es de prueba
    private int Level;

    void Start()
    {
        k = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        keyPressed = false;
        transform.position = startPos;
        Level = 1;
    }

    void Update()
    {
        if(Input.GetKey(keyCode))
        {
            keyPressed = true;
        }
        else
        {
            keyPressed = false;
        }

        if(rb.velocity.y<SpeedOfMaxAngle && rb.velocity.y > -SpeedOfMaxAngle)
        {
            transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * maxAngle / SpeedOfMaxAngle);
        }
        else
        {
            if(rb.velocity.y > SpeedOfMaxAngle)
            {
                transform.rotation = Quaternion.Euler(0, 0, maxAngle);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -maxAngle);
            }
        }

        if(k)
        {
            elapsedTime += Time.deltaTime;
            elapsedTimeInt = Mathf.FloorToInt(elapsedTime);

            timeLeft = 96 - elapsedTimeInt;

        }

        if(elapsedTimeInt>=96)
        {
            if(k)
            {
                k = false;
                Generator.GenerateMoney();
            }
        }

        Debug.Log(timeLeft);
    }

    void FixedUpdate()
    {
        if (keyPressed)
        {
            rb.AddForce(new Vector2(0, force));
        }

        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(0, maxSpeed);
        }

        if (rb.velocity.y < -maxSpeed)
        {
            rb.velocity = new Vector2(0, -maxSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Asteroid"))
        {
            GameOver();
        }
        if(other.CompareTag("Coin"))
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        Debug.Log("Minigame 1 - Level1. Completed");
        Time.timeScale = 0.0f;

    }

    void GameOver()
    {
        Debug.Log("Asteroid or the colliders were hit.");
        Debug.Log("There were " + timeLeft + " seconds to finish the minigameS");
        Destroy(gameObject);
    }

    
}