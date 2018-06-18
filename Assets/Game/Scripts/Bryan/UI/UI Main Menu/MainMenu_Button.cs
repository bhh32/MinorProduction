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
                SceneManager.LoadScene("Development");
                break;
            case "Options":
                // Deactivate Main Menu Canvas and Activate Options Canvas
                break;
            case "Credits":
                // Deactivate Main Menu Canvas and Activate Credits Menu
                break;
            case "Quit Game":
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
