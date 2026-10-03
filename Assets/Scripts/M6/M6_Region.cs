using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M6_Region : MonoBehaviour
{
    public int size;
    private EcoTexture regionTexture;

    public SpriteRenderer spriteRenderer;
    public SpriteRenderer itemRenderer;
    public PolygonCollider2D polygonCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        regionTexture = new EcoTexture(4 * size, 4 * size);
        regionTexture.FillWith(Color.green);

        UpdateSprite();
    }


    public void UpdateSprite()
    {
        Sprite newSprite = Sprite.Create(regionTexture.Export(FilterMode.Point), new Rect(0, 0, regionTexture.width, regionTexture.height), new Vector2(0.5f, 0.5f), size);
        spriteRenderer.sprite = newSprite;


    }
}
