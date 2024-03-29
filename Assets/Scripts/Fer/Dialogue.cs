using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 5)] private string[] dialogueLines;


    private float typingTime = 0.01f;


    private bool isPlayerInRange;
    public bool didDialogueStart;
    private int lineIndex;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {

            if (!didDialogueStart)
            {
                StartDialogue();

            }
            else if (dialogueText.text == dialogueLines[lineIndex]){
                NextDialogueLine();
            }
            else {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        //dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale=0f;
        StartCoroutine(ShowLine());
    }

    public void NextDialogueLine(){
        lineIndex++;
        if  (lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }
        else {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            //dialogueMark.SetActive(true);
            Time.timeScale=1f;
        }
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PJ"))
        {
            isPlayerInRange = true;
            //dialogueMark.SetActive(true);
            Debug.Log("Se puede activar dialogo");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PJ"))
        {
            isPlayerInRange = false;
            //dialogueMark.SetActive(false);
            Debug.Log("No se puede activar dialogo");
        }
    }
}
