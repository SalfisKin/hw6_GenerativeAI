using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueBox;
    public GameObject imageObject;
    public TMP_Text introductionText;
    public TMP_Text button1;
    public TMP_Text button2;
    public TMP_Text button3;
    public PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayMessage(string message)
    {
        playerScript.isDialogueOpen = true;
        //GameObject.Find("Canvas").setActive(true);
        Console.WriteLine("Called Dialogue manager");
        dialogueBox.SetActive(true);
        introductionText.text = message;
    }

    public void displayButtons(string[] items)
    {
        button1.text = items[0];
        button2.text = items[1];
        button3.text = items[2];
    }

    public void closeDialouge()
    {
        dialogueBox.SetActive(false);
        playerScript.freeze = false;
        playerScript.isDialogueOpen = false;
    }
}
