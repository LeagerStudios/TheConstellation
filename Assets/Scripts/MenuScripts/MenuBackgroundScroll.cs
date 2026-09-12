using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundScroll : MonoBehaviour
{
    public float velocity;
    RectTransform tr;

    void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    void Update()
    {
        tr.anchoredPosition = new Vector3(tr.anchoredPosition.x + velocity * Time.deltaTime, tr.anchoredPosition.y);

        if(tr.anchoredPosition.x > 1080)
        {
            tr.anchoredPosition = new Vector3(tr.anchoredPosition.x - 1080, tr.anchoredPosition.y);
        }
    }
}
