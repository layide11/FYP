using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue __Dialogue;

    public void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(__Dialogue);
    }
}
