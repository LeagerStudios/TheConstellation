using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManolitoController : MonoBehaviour
{
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }
    
    void Update()
    {
        tr.position = new Vector3(transform.position.x - 1f * Time.deltaTime, transform.position.y, transform.position.z);
        tr.Rotate(0, 0, -30 * Time.deltaTime);
    }
}
