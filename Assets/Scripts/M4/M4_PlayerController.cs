using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4_PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public int playerHealth;
    bool wantsToJump;
    bool canJump;
    
    void Start()
    {
        wantsToJump = false;
        canJump = false;
    }

    void Update()
    {

        if (GInput.GetKeyDown(KeyCode.W) && canJump)
        {
            wantsToJump = true;
        }

    }

}
