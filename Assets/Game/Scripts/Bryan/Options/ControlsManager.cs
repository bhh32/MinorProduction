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
    }

    #endregion

    [SerializeField] Toggle controlsToggle;
    public bool isPointAndClick = false;

    void Update()
    {
        if (controlsToggle.isOn)
            isPointAndClick = true;
        else
            isPointAndClick = false;
    }
}
