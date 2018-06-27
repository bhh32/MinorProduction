using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TMP_Text button;

    Color32 origButtonColor;
    Color32 hoverButtonColor;

    void Start()
    {
        origButtonColor = button.faceColor;
        hoverButtonColor = new Color32(1, 51, 1, 255);
    }

    #region IPointerClickHandler implementation
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Main Menu");
    }
    #endregion
    
    #region IPointerEnterHandler implementation
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.color = hoverButtonColor;
    }
    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        button.color = origButtonColor;
    }

    #endregion
}
