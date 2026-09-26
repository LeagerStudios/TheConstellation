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
    [SerializeField] LayerMask groundMask;
    RaycastHit2D groundRaycast;
    bool canJump;
    bool wantToJump;
    public float targetSpeed;
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
        playerSpeed = 6f;
        playerJumpForce = 350;
        deceleration = 13.5f;

    }
    
    void Update()
    {

        groundRaycast = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundMask);

        canJump = groundRaycast.collider != null;

        targetSpeed = 0f;

        if (GInput.GetKeyDown(KeyCode.W) && canJump)
        {
            wantToJump = true;
        }

        if (GInput.GetKey(KeyCode.A))
        {

            targetSpeed = -playerSpeed;

        }

        if (GInput.GetKey(KeyCode.D))
        {

            targetSpeed = playerSpeed;

        }

    }

    void FixedUpdate()
    {

        if (wantToJump)
        {

            rb.AddForce(new Vector2(0, playerJumpForce));

            wantToJump = false;
            
        }

        //Generates the velocity and if there was a movement before, it cancels it so that the new movement can be done quicker.
        newVelocity = Mathf.MoveTowards(rb.velocity.x, targetSpeed, deceleration * Time.fixedDeltaTime);

        rb.velocity = new Vector2(newVelocity, rb.velocity.y);

    }

}
