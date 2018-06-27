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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        controlsToggle = GameObject.Find("Point And Click Toggle");
        toggle = controlsToggle.GetComponent<Toggle>();
    }

    #endregion

    [SerializeField] GameObject controlsToggle;
    Toggle toggle;
    public bool isPointAndClick = false;

    void Update()
    {
        if (toggle.isOn)
            isPointAndClick = true;
        else
            isPointAndClick = false;
    }
}
