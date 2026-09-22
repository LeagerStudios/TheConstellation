using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if(transform.position.x >= -5)
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
    }
}
