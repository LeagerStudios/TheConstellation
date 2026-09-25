using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2_Manager : MonoBehaviour
{

    PlayerM2 playerScript;

    void Start()
    {

        playerScript = FindObjectOfType<PlayerM2>();

    }

    void Update()
    {
        
        while(playerScript.playerHealth > 0)
        {
            //minigameLogic
        }

        if(playerScript.playerHealth == 0)
        {
            Debug.Log("Te has hecho la murición pro max");
        }

    }

}
