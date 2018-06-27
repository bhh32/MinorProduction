using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] GameObject controlsToggle;
    [SerializeField] Toggle toggle;
    public bool isPointAndClick = false;

    void FixedUpdate()
    {
        // Puts the control toggle into the cached variable if it exists
        // if it doesn't then the gameobject is destroyed.
        if (controlsToggle == null)
        {
            controlsToggle = GameObject.Find("Point And Click Toggle");

            if (controlsToggle == null)
                Destroy(gameObject);

            toggle = controlsToggle.GetComponent<Toggle>();
        }
    }

    void Update()
    {
        if (toggle.isOn)
            isPointAndClick = true;
        else
            isPointAndClick = false;
    }
}
