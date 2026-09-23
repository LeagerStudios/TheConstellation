using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerM1 : MonoBehaviour
{
    private int obtainedCoins; //en principio las monedas se consiguen siempre en orden en el M1, asiq no hace falta crear un bool para cada moneda por cada moneda independiente
    private bool k;
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
    public int Level;

    void Start()
    {
        k = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        keyPressed = false;
        transform.position = startPos;
        Level = 1;
        obtainedCoins = 0;
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

            timeLeft = levelDurations[Level-1] - elapsedTimeInt;

        }

        if(elapsedTimeInt >= levelDurations[Level-1])
        {
            if(k)
            {
                k = false;
                Generator.GenerateMoney();
            }
        }
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
        Debug.Log("Minigame 1 - Level" + Level + " completed");
        if(Level < 3)
        {
            StartCoroutine(StartNewLevel());
            obtainedCoins++;
            Debug.Log(obtainedCoins);
        }
        else
        {
            Debug.Log("Minigame 1 completed");
            obtainedCoins = 3;
            Win();
        }
    }

    void GameOver()
    {
        Debug.Log("Asteroid or the colliders were hit.");
        Debug.Log("There were " + timeLeft + " seconds to finish the minigameS");
        Destroy(gameObject);
    }

    void Win()
    {
        //idk metanle algo si qren
    }

    public IEnumerator StartNewLevel()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0.5f);
        Level++;
        elapsedTime = 0f;
        elapsedTimeInt = 0;
        k = true;
        Generator.canGenerateAsteroid = true;
    }
}