using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public PlayerM1 playerScript;

    public float[] speeds = { 10f, 15f, 20f };

    void Awake()
    {
        playerScript = FindObjectOfType<PlayerM1>();
    }

    void Update()
    {
        if (transform.position.x <= -9)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector2(transform.position.x - speeds[playerScript.Level - 1] * Time.deltaTime, transform.position.y);
    }
}
