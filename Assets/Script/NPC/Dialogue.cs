using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public TMP_Text dialogueText;
    public List<string> dialogues;
    public float writingSpeed = 1f;
    private int index;
    private int charIndex;
    bool isStarted = false;
    bool canNextDialogoue;
    public bool isEnded = false;

    void Awake(){
        ToggleWindow(false);
        ToggleIndicator(false);
    }

    void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    public void StartDialogue()
    {
        if (isStarted) return;
        isStarted = true;
        ToggleWindow(true);
        ToggleIndicator(false);
        GetDialogue(0);
    }

    void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }

    void EndDialogue()
    {
        ToggleWindow(false);
    }


    IEnumerator Writing()
    {
        // yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        dialogueText.text += currentDialogue[charIndex];
        charIndex++;
        if (charIndex < currentDialogue.Length)
        {
            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());
        }
        else
        {
            canNextDialogoue = true;
        }
    }

    void Update()
    {
        if (!isStarted) return;
        if (canNextDialogoue && Input.GetKeyDown(KeyCode.F))
        {
            canNextDialogoue = false;
            index++;
            if (index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                isEnded = true;
                EndDialogue();
            }
        }
    }


}
