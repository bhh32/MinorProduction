using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverToolTip : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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

    #region IPointerClickHandler implementation
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Walk Button":
                UIActionManager.instance.SetAction_Walk();
                break;
            case "Pick Up Button":
                UIActionManager.instance.SetAction_PickUp();
                break;
            case "Look At Button":
                UIActionManager.instance.SetAction_LookAt();
                break;
            case "Use Button":
                UIActionManager.instance.SetAction_Use();
                break;
            case "Open Button":
                UIActionManager.instance.SetAction_Open();
                break;
            case "Close Button":
                UIActionManager.instance.SetAction_Close();
                break;
            case "Talk To":
                UIActionManager.instance.SetAction_TalkTo();
                break;
            case "Push":
                UIActionManager.instance.SetAction_Push();
                break;
            case "Pull":
                UIActionManager.instance.SetAction_Pull();
                break;
            default:
                Debug.LogError("Something went wrong with button clicking!" + gameObject.name);
                break;
        }
    }
    #endregion
}
