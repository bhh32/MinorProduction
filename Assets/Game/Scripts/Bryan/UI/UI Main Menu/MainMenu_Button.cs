using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu_Button : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    #region IPointerClickHandler implementation
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Play":
                DontDestroyOnLoad(ControlsManager.instance.gameObject);
                SceneManager.LoadScene("Development");
                break;
            case "Credits":
                SceneManager.LoadScene("Credits");
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                Debug.LogError("Something went wrong with this button: " + gameObject.name);
                break;
        }
    }
    #endregion
    
    #region IPointerEnterHandler implementation
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Sprite Change to highlighted
    }
    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        // Sprite change to idle
    }

    #endregion
}
