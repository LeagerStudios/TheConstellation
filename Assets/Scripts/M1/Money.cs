using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if(transform.position.x >= -4)
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
    }
}
