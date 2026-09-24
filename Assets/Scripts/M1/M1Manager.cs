using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1Manager : MonoBehaviour
{
    public bool alive;
    private int obtainedCoins; //en principio las monedas se consiguen siempre en orden en el M1, asiq no hace falta crear un bool para cada moneda por cada moneda independiente
    private bool k;
    public float elapsedTime = 0f;
    public int elapsedTimeInt = 0;
    public int timeLeft;
    public int[] levelDurations = { 20, 10, 30 }; //obviamente van a durar más, esto es de prueba
    public int Level;
    public bool canGenerateAsteroid;
    public GameObject AsteroidPrefab;
    public GameObject MoneyPrefab;
    public float asteroidXpos;
    public float maxYpos, minYpos;
    public float waitTime;
    public Vector2 moneySpawnPosition;

    void Start()
    {
        alive = true;
        InvokeRepeating(nameof(GenerateAsteroid), 0f, waitTime);
        canGenerateAsteroid = true;
        Level = 1;
        obtainedCoins = 0;
        k = true;
    }

    void Update()
    {
        if (k)
        {
            elapsedTime += Time.deltaTime;
            elapsedTimeInt = Mathf.FloorToInt(elapsedTime);

            timeLeft = levelDurations[Level - 1] - elapsedTimeInt;
        }

        if (elapsedTimeInt >= levelDurations[Level - 1])
        {
            if (k && alive)
            {
                k = false;
                GenerateMoney();
            }
        }
    }

    void GenerateAsteroid()
    {
        float Ypos = Random.Range(minYpos, maxYpos);
        if(canGenerateAsteroid)
        {
            Instantiate(AsteroidPrefab, new Vector2(asteroidXpos, Ypos), Quaternion.identity);
        }
    }

    private void GenerateMoney()
    {
        canGenerateAsteroid = false;
        Instantiate(MoneyPrefab, moneySpawnPosition, Quaternion.identity);
    }

    public void EndLevel()
    {
        if(Level < 3)
        {
            StartCoroutine(StartNewLevel());
            obtainedCoins++;
            Debug.Log(obtainedCoins);
        }
        else
        {
            obtainedCoins = 3;
            Win();
        }
    }

    public void GameOver()
    {
        alive = false;
    }

    public void Win()
    {
        
    }

    public IEnumerator StartNewLevel()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0.5f);
        Level++;
        elapsedTime = 0f;
        elapsedTimeInt = 0;
        k = true;
        canGenerateAsteroid = true;
    }
}
