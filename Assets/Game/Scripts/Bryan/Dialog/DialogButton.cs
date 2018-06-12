using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogButton : MonoBehaviour, IPointerClickHandler 
{
    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        DialogSystemManager.instance.UpdateCurrentChoice(gameObject);
        DialogSystemManager.instance.DialogChoices();
    }

    #endregion
}
