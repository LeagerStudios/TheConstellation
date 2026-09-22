using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerM1 : MonoBehaviour
{
    private bool k; //ni se os ocurra quitarlo este bool es esencial para tda lo lógica del juego ok? Gofre: Podrías haberle puesto un nombre descriptivo XD
    // private int level;
    public Rigidbody2D rb;
    public float force;
    public float maxSpeed;
    public Vector2 startPos;
    private bool keyPressed;
    public KeyCode keyCode;
    public float maxAngle;
    public float SpeedOfMaxAngle;
    public int points = 0;
    public float elapsedTime = 0f;
    public Generator Generator;

    void Start()
    {
        k = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        keyPressed = false;
        transform.position = startPos;
        points = 0;
        // level = 0;
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
            points = Mathf.FloorToInt(elapsedTime * 1000);
        }

        if(points < 10000)
        {
            Debug.Log(points);
        }
        

        if(points>=10000)
        {
            if(k)
            {
                k = false;
                Generator.GenerateMoney();
            }
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
            Debug.Log("Ganaste lol");
            Time.timeScale = 0.0f;
        }
    }

    void GameOver()
    {
        Debug.Log("Perdiste lol");
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if(keyPressed)
        {
            rb.AddForce(new Vector2(0, force));
        }

        if(rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(0, maxSpeed);
        }

        if (rb.velocity.y < -maxSpeed)
        {
            rb.velocity = new Vector2(0, -maxSpeed);
        }
    }
}