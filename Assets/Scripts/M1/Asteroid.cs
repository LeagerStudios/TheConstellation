using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if(transform.position.x <= -9)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
