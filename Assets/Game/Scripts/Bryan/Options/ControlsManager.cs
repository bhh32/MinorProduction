using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlsManager : MonoBehaviour 
{
    #region Singleton

    public static ControlsManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField] Toggle toggle;
    [SerializeField] TMP_Text movementText;
    public bool isPointAndClick = false;

    void FixedUpdate()
    {
        // Puts the control toggle into the cached variable if it exists
        // if it doesn't then the gameobject is destroyed.
        if(toggle == null)
        { 
            foreach (Toggle tog in FindObjectsOfType<Toggle>())
            {
                if (tog.name == "Point And Click Toggle")
                {
                    toggle = tog;
                    break;
                }
            }

            if (toggle == null)
                Destroy(gameObject);
        }

        if (movementText == null)
        {
            foreach (TMP_Text text in FindObjectsOfType<TMP_Text>())
            {
                if (text.name == "Movement Controls")
                {
                    movementText = text;
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (toggle.isOn)
        {
            isPointAndClick = true;
            Text toggleLable = toggle.GetComponentInChildren<Text>();
            toggleLable.text = "Point And Click Controls Enabled";
            movementText.text = "Left Mouse Click (When Action Not Selected) - Walk";
        }
        else
        {
            isPointAndClick = false;
            Text toggleLable = toggle.GetComponentInChildren<Text>();
            toggleLable.text = "WASD Controls Enabled";
            movementText.text = "WASD - Walk";
        }
    }
}
