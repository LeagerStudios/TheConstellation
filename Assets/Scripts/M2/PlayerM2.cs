using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM2 : MonoBehaviour
{

    //Components and Classes
    public KeyCode keyCode;
    InputManager I_Manager;
    Rigidbody2D rb;
    SpriteRenderer sr;
    
    //Some variables used for movements and deceleration
    [SerializeField] float deceleration;
    float targetSpeed;
    float newVelocity;

    //Player attributes
    public int playerHealth;
    public float playerSpeed;
    public int playerJumpForce;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        playerHealth = 100;
        playerSpeed = 7.5f;
        playerJumpForce = 500;
        deceleration = 12.5f;

    }
    
    void Update()
    {
        //Ta solito XDXDXD
    }

    private void FixedUpdate()
    {

        targetSpeed = 0f;

        if (GInput.GetKeyDown(KeyCode.W))
        {

            rb.AddForce(new Vector2(0, playerJumpForce));
            
        }

        if (GInput.GetKey(KeyCode.A))
        {

            targetSpeed = -playerSpeed;

        }

        if (GInput.GetKey(KeyCode.D))
        {

            targetSpeed = playerSpeed;

        }

        //Generates the velocity and if there was a movement before, it cancels it so that the new movement can be done quicker.
        newVelocity = Mathf.MoveTowards(rb.velocity.x, targetSpeed, deceleration * Time.fixedDeltaTime);

        rb.velocity = new Vector2(newVelocity, rb.velocity.y);

    }

}
