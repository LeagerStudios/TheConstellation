using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerM1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public float maxSpeed;
    public Vector2 startPos;
    private bool keyPressed;
    public KeyCode keyCode;
    public float maxAngle;
    public float SpeedOfMaxAngle;


    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        keyPressed = false;
        transform.position = startPos;
        points = 0;
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Asteroid"))
        {
            GameOver();
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