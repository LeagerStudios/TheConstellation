using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public KeyCode keyCode;
    InputManager I_Manager;
    private bool keyPressed;
    Rigidbody2D rb;
    SpriteRenderer sr;

    int playerHealth;

    void Start()
    {

        //Assignment of components or variables.
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        keyPressed = false;
        playerHealth = 100;

    }
    
    void Update()
    {
        if (Input.GetKey(keyCode))
        {
            keyPressed = true;
        }
        else
        {
            keyPressed = false;
        }
    }

    private void FixedUpdate()
    {
        if (GInput.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, 100));
        }

    }

}
