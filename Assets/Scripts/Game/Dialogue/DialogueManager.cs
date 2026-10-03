using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager self;
    public GameObject panel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image dialogueImage;

    public KeyCode nextKey = KeyCode.E;

    Dialogue dialogue;
    int index;
    bool dialogueActive = false;
    Coroutine typingCoroutine;
    bool canSkipCoroutine = false;


    void Awake()
    {
        self = this;
        panel.SetActive(false);
    }

    void Update()
    {
        if (!dialogueActive) return;

        if (Input.GetKeyDown(nextKey))
        {
            if (typingCoroutine != null && canSkipCoroutine)
            {
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;
                ShowLine(false);
                return;
            }
            else if (typingCoroutine == null)
            {
                if (index >= dialogue.lines.Length - 1)
                {
                    EndDialogue();
                }
                else
                {
                    index++;
                    ShowLine(true);
                }
            }
        }
    }

    public void StartDialogue(Dialogue newDialogue)
    {
        if (dialogueActive) return;
        dialogueActive = true;
        dialogue = newDialogue;
        index = 0;
        canSkipCoroutine = false;

        panel.SetActive(true);
        ShowLine(true);
    }


    void ShowLine(bool coroutine)
    {
        canSkipCoroutine = false;
        if (coroutine)
        {
            typingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            dialogueImage.sprite = dialogue.lines[index].characterImage;
            nameText.text = dialogue.lines[index].name;
            dialogueText.text = dialogue.lines[index].text;
        }
    }

    void EndDialogue()
    {
        StartCoroutine(EndDialogueCorroutine());
    }

    private IEnumerator EndDialogueCorroutine()
    {
        yield return new WaitForEndOfFrame();
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = null;
        dialogue = null;
        dialogueActive = false;
        panel.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return dialogueActive;
    }

    IEnumerator TypeLine()
    {
        dialogueImage.sprite = dialogue.lines[index].characterImage;
        nameText.text = dialogue.lines[index].name;
        dialogueText.text = "";
        yield return new WaitForSeconds(0.02f);
        canSkipCoroutine = true;

        foreach (char c in dialogue.lines[index].text.ToCharArray())
        {
            dialogueText.text += c;
            if (c != ' ')
                if (AudioManager.self != null && AudioManager.self.audioSource != null)
                {
                    if (dialogue.lines[index].voice != null)
                    {
                        AudioManager.self.audioSource.PlayOneShot(dialogue.lines[index].voice);
                    }
                }
            yield return new WaitForSeconds(dialogue.lines[index].typingSpeed);
        }
        typingCoroutine = null;
    }
}
