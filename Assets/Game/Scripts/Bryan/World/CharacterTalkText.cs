using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTalkText : MonoBehaviour 
{
    #region Singleton

    public static CharacterTalkText instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Text talkingText { private get; set; }

    public float textTimer = 3f;

	// Update is called once per frame
	void Update () 
    {
        textTimer += Time.deltaTime % 60f;
        TextActivateDeactivate(textTimer);
	}

    void TextActivateDeactivate(float timer)
    {
//        if (timer < 3f)
//            talkingText.enabled = true;
//        else
//        {
//            talkingText.enabled = false;
//            //Camera.main.
//        }
    }
}
