using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10.0f;

    public bool meetNPC = false;
    public bool freeze = false;
    public string npcName;

    private float horizontalMovement;
    public ChatGPTScript chatGPTScript;


    private Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            m_Rigidbody.velocity = new Vector2(horizontalMovement * speed, m_Rigidbody.velocity.y);
        }

        if (meetNPC & npcName != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                freeze = true;
                chatGPTScript.SendReply(npcName);
            }
        }

    }
}
