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
    public float textDelay = 4.5f;

    // Text position offset from the player
    Vector3 offSet;

    // Flag to say if the text is currently enabled or disabled
    public bool isTextEnabled { get; set; }
    bool canDisable = true;

    void Start()
    {
        // Start with the text disabled
        isTextEnabled = false;

        // Setup the position offset from the character
        offSet = transform.position - talkingText.transform.position;
    }

	void Update () 
    {
        // Check to see if the text is enabled or can disable
        if (isTextEnabled)
        {
            isTextEnabled = false;
            canDisable = false;
            talkingText.enabled = true;
            StartCoroutine(DelayText(textDelay));
        }
        else if (canDisable)
        {
            talkingText.enabled = false;
        }

        // Set the texts position according to the character and the offset
        talkingText.transform.position = new Vector3(transform.position.x, transform.position.y - offSet.y, transform.position.z);
	}

    // Updates the text *Note: Called from other scripts
    public void TextUpdate(string updateText)
    {
        talkingText.text = updateText;
    }

    IEnumerator DelayText(float delay)
    {
        yield return new WaitForSeconds(delay);
        talkingText.enabled = false;
        canDisable = true;

    }
}
