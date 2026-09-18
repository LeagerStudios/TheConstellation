using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject AsteroidPrefab;
    public float Xpos;
    public float maxYpos, minYpos;
    public float waitTime;

    void Start()
    {
        InvokeRepeating(nameof(GenerateAsteroid), 0f, waitTime);
    }

    void GenerateAsteroid()
    {
        float Ypos = Random.Range(minYpos, maxYpos);

        Instantiate(AsteroidPrefab, new Vector2(Xpos, Ypos), Quaternion.identity);
    }
}
