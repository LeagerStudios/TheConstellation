using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool canGenerateAsteroid;
    public GameObject AsteroidPrefab;
    public GameObject MoneyPrefab;
    public float asteroidXpos;
    public float maxYpos, minYpos;
    public float waitTime;
    public Vector2 moneySpawnPosition;

    void Start()
    {
        InvokeRepeating(nameof(GenerateAsteroid), 0f, waitTime);
        canGenerateAsteroid = true;
    }

    void GenerateAsteroid()
    {
        float Ypos = Random.Range(minYpos, maxYpos);
        if(canGenerateAsteroid)
        {
            Instantiate(AsteroidPrefab, new Vector2(asteroidXpos, Ypos), Quaternion.identity);
        }
    }

    public void GenerateMoney()
    {
        canGenerateAsteroid = false;
        Instantiate(MoneyPrefab, moneySpawnPosition, Quaternion.identity);
    }
}
