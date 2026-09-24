using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public M1Manager manager;

    public float[] speeds = { 10f, 15f, 20f };

    void Awake()
    {
        manager = FindObjectOfType<M1Manager>();
    }

    void Update()
    {
        if (transform.position.x <= -9)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector2(transform.position.x - speeds[manager.Level - 1] * Time.deltaTime, transform.position.y);
    }
}
