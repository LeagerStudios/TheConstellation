using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class M1UI : MonoBehaviour //la UI de la escena es provisional, ya la pondremos más bonita
{
    public TextMeshProUGUI timeLeft;
    public TextMeshProUGUI level;
    public M1Manager manager;

    void Update()
    {
        if(manager.alive)
        {
            timeLeft.text = "Time left: " + manager.timeLeft.ToString() + "s";
            level.text = "Level " + manager.Level.ToString();
        }
    }
}
