using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class ButtonController : MonoBehaviour
{
    
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

    public void QuitButton()
    {
        Application.Quit();

        //el #if es como decir "este codigo solo existe si x"
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
