using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M6_RegionController : MonoBehaviour
{
    public GameObject regionPrefab;

    public Dictionary<Vector2Int, M6_Region> regions;
    void Start()
    {
        regions = new Dictionary<Vector2Int, M6_Region>();
    }

    
    void Update()
    {
        
    }

    public void UpdateRegions(Vector2 playerPosition)
    {
        Vector2Int position = Vector2Int.RoundToInt(playerPosition / 4);
    }

}
