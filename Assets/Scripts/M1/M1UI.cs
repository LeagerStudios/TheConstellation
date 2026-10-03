using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class M1UI : MonoBehaviour //la UI de la escena es provisional, ya la pondremos más bonita
{
    public TextMeshProUGUI timeLeft;
    public TextMeshProUGUI level;
    public M1Manager manager;
    public GameObject gameOverMenu;

    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if(manager.alive)
        {
            timeLeft.text = "Time left: " + manager.timeLeft.ToString() + "s";
            level.text = "Level " + manager.Level.ToString();
        }
    }

    public void Die()
    {
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Minigame1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MinigameSelection");
    }
}
