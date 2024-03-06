using OpenAI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatGPTScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public DialogueManager dialogueManager;

    private float height;
    private OpenAIApi openai = new OpenAIApi();

    private List<ChatMessage> messages = new List<ChatMessage>();
    private string prompt = "As a {0} in the rpg village, give a one sentence introduction to your self and give a list of what you should be selling as a {1}. put 3 items you are selling into a list and the format of item in list is <ItemName>: +<number> defense +<number> attack +<number> health. replace the ItemName with name and number with number. use : before start listing";

    private void Start()
    {

    }

    public async void SendReply(string role)
    {
        var newMessage = new ChatMessage()
        {
            Role = "user",
            Content = string.Format(prompt, role, role)
        };


        if (messages.Count == 0) newMessage.Content = string.Format(prompt,role,role);

        messages.Add(newMessage);


        // Complete the instruction
        var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
        {
            Model = "gpt-3.5-turbo-0613",
            Messages = messages
        });

        if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
        {
            var message = completionResponse.Choices[0].Message;
            message.Content = message.Content.Trim();
            messages.Add(message);
            Debug.Log(message.Content);
            string NPCIntroAndItems = message.Content;
            int firstIndex = NPCIntroAndItems.IndexOf(":");
            //string[] introAndItems = NPCIntroAndItems.Split(new string[] { ":" }, firstIndex);
            string introduction = NPCIntroAndItems.Substring(0, firstIndex);
            dialogueManager.displayMessage(introduction);
            string itemList = NPCIntroAndItems.Substring(firstIndex + 1);
            string[] items = itemList.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            dialogueManager.displayButtons(items);
            Debug.Log(introduction);
            foreach(string item in items)
            {
                Debug.Log(item);
            }
        }
        else
        {
            Debug.LogWarning("No text was generated from this prom" +
				"pt.");
            dialogueManager.displayMessage("Error conntecting ChatGPT");
        }

    }
}

