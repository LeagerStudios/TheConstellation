using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M6_Region : MonoBehaviour
{
    public Vector2Int size;
    private Texture2D regionTexture;

    public SpriteRenderer spriteRenderer;
    public SpriteRenderer itemRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        regionTexture = new Texture2D(4 * size.x, 4 * size.y);
    }


    void Update()
    {
        
    }
}
