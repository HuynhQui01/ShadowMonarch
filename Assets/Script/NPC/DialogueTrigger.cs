using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool isDetectedPlayer = false;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            if (!dialogue.isEnded)
            {
                isDetectedPlayer = true;
                dialogue.ToggleIndicator(isDetectedPlayer);
            }

        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            isDetectedPlayer = false;
            dialogue.ToggleIndicator(isDetectedPlayer);
        }
    }

    void Update()
    {
        if (isDetectedPlayer && Input.GetKeyDown(KeyCode.F))
        {
            dialogue.StartDialogue();
        }
    }
}
