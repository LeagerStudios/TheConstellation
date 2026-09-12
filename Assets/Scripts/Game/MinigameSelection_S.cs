using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MinigameSelection_S : MonoBehaviour
{

    public Button Trigger;

    void Start()
    {
    }

    void Update()
    {
    }

    public void buttonPressed()
    {
        SceneManager.LoadScene(Trigger.name);
    }

}
