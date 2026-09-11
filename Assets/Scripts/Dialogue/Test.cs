using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    void Start()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
