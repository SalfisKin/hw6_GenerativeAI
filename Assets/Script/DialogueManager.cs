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
        //GameObject.Find("Canvas").setActive(true);
        Console.WriteLine("Called Dialogue manager");
        dialogueBox.SetActive(true);
        introductionText.text = message;
    }
}
