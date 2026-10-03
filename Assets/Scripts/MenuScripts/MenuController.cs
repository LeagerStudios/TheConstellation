using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System;

public class MenuController : MonoBehaviour
{
    public void Start()//ejemplito del sistema de guardado, no tiene nada que ver con el menu xdxdxd
    {

    }

    public void PlayButton()
    {
        SceneManager.LoadScene("MinigameSelection");
    }

    public void SettingsButton()
    {
        //Ya lo haré otro día xdxdxd
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToggleShader(bool shader)
    {
        OptionsManager.ShaderOn = shader;
    }

    public void QuitButton()
    {
        Application.Quit();

        //el #if es como decir "este codigo solo existe si x"
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
