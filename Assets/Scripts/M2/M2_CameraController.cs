using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2_CameraController : MonoBehaviour
{

    [SerializeField] GameObject Player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
    }
}
