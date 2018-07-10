using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateAndUpdateCineText : MonoBehaviour 
{
    [SerializeField] TMP_Text talkingText;

    public float delay = 4.5f;

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            if (gameObject.name == "Indy Text Update")
            {
                switch (talkingText.text)
                {
                    case "New Text":
                        TextUpdate("Sophia?! How'd you get over here?");
                        break;
                    case "Sophia?! How'd you get over here?":
                        UIActionManager.instance.isTalking = true;
                        DialogSystemManager.instance.DisableOtherUI();
                        break;
                    default:
                        Debug.LogError("Something went wrong: " + gameObject.name);
                        break;
                }
            }
            else if (gameObject.name == "Sophia Text Update")
            {
                switch (talkingText.text)
                {
                    case "New Text":
                        TextUpdate("While you were off bushwacking, I found a path.");
                        break;
                    default:
                        Debug.LogError("Something went wrong: " + gameObject.name);
                        break;
                }
            }
            else if (gameObject.name == "Sternhart Text Update")
            {
                switch (talkingText.text)
                {
                    case "New Text":
                        TextUpdate("Can I help you? Post card? Souvenir?");
                        break;
                    default:
                        Debug.LogError("Something went wrong: " + gameObject.name);
                        break;
                }
            }

        }
    }

    void TextUpdate(string updateText)
    {
        talkingText.text = updateText;
    }
}
