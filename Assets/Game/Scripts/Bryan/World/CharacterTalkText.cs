using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterTalkText : MonoBehaviour 
{
    // Text above the character for speech
    [SerializeField] TMP_Text talkingText;

    // Timer for delay of text enable and disable
    public float textTimer = 3f;

    // Text position offset from the player
    Vector3 offSet;

    // Flag to say if the text is currently enabled or disabled
    public bool isTextEnabled { get; set; }

    void Start()
    {
        // Start with the text disabled
        isTextEnabled = false;

        // Setup the position offset from the character
        offSet = transform.position - talkingText.transform.position;
    }

	void Update () 
    {
        // Update the text timer
        textTimer -= Time.deltaTime % 60f;

        // Check to see if the text is enabled
        if (isTextEnabled)
        {
            TextActivateDeactivate();
        }

        // Safety check to ensure the text is disabled when it needs to be
        if (!isTextEnabled && talkingText.enabled)
            talkingText.enabled = false;

        if (textTimer < 0f)
        {
            textTimer = 6f;
        }

        // Set the texts position according to the character and the offset
        talkingText.transform.position = new Vector3(transform.position.x, transform.position.y - offSet.y, transform.position.z);
	}

    // Activates and Deactivates the speech text according to the timer
    void TextActivateDeactivate()
    {
        // Check to ensure the text timer is greater than 6 secs and more than 0 secs
        if (textTimer < 6f && textTimer > 0f)
        {            
            // if so, enable the text
            talkingText.enabled = true;
        }
        else
        {
            // if not, disable the text and set the flag to false
            talkingText.enabled = false;
            isTextEnabled = false;
        }
    }

    // Updates the text *Note: Called from other scripts
    public void TextUpdate(string updateText)
    {
        talkingText.text = updateText;
    }
}
