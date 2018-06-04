using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverToolTip : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField] Text toolTip;
    [SerializeField] TMP_Text toolTip;

    void Start()
    {
        toolTip.enabled = false;
    }

    #region IPointerEnterHandler implementation
    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.enabled = true;
    }
    #endregion
    
    #region IPointerExitHandler implementation
    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.enabled = false;
    }
    #endregion
}
