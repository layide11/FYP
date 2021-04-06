using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text __DialogueText;
    private Queue<string> __Sentences;



    public void StartDialogue(Dialogue dialogue)
    {
        __Sentences = new Queue<string>();

        foreach (string _Sentence in dialogue.__Sentences)
        {
            __Sentences.Enqueue(_Sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (__Sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            string _Sentence = __Sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(_Sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        __DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            __DialogueText.text += letter;
            yield return null;
        }

    }

    public void EndDialogue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
