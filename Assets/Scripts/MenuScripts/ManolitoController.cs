using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManolitoController : MonoBehaviour
{
    RectTransform tr;

    void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    void Update()
    {
        tr.anchoredPosition = new Vector3(tr.anchoredPosition.x - 50f * Time.deltaTime, tr.anchoredPosition.y);
        tr.Rotate(0, 0, -30 * Time.deltaTime);
    }
}
