using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10.0f;

    public bool meetNPC = false;
    public bool freeze = false;
    public string npcName;

    private float horizontalMovement;
    public ChatGPTScript chatGPTScript;
    private Animator player_Animator; // Reference to the Animator component

    private Rigidbody2D m_Rigidbody;

    public bool isDialogueOpen = false;
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        player_Animator = GetComponent<Animator>(); // Initialize the Animator component
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            m_Rigidbody.velocity = new Vector2(horizontalMovement * speed, m_Rigidbody.velocity.y);

            // Check if the player is moving by comparing horizontal movement to zero
            bool isRunning_right = (horizontalMovement > 0);
            player_Animator.SetBool("Is_running_right", isRunning_right); // Set the Animator's isRunning parameter
            bool isRunning_left = (horizontalMovement < 0);
            player_Animator.SetBool("Is_running_left", isRunning_left); // Set the Animator's isRunning parameter
        }

        if (meetNPC & npcName != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(isDialogueOpen)
                {
                    dialogueManager.closeDialouge();
                }
                else
                {
                    freeze = true;
                    chatGPTScript.SendReply(npcName);
                    player_Animator.SetBool("Is_running", false);
                }
            }
            

        }

    }
}
