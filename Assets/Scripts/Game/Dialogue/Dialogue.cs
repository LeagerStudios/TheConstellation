using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string name;
    public string text;
    public AudioClip voice;
    public Sprite characterImage;
    public float typingSpeed = 0.035f;
}

[CreateAssetMenu(menuName = "GameStuff/Events/Dialogue", fileName = "newDialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueLine[] lines;
}